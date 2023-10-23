namespace Arch.Core.Extensions.Dangerous;

/// <summary>
///     The <see cref="DangerousEntityExtensions"/> class
///     contains several <see cref="Entity"/> related extension methods which give acess to underlaying data structures that should only be modified when you exactly know what you are doing.
/// </summary>
public static class DangerousEntityExtensions
{
    /// <summary>
    ///     Creates an <see cref="Entity"/> struct and returns it.
    ///     Does not create an <see cref="Entity"/> in the world, just the plain struct.
    /// </summary>
    /// <param name="id">Its id.</param>
    /// <param name="world">Its world id. Unused if PURE_ECS is set.</param>
    /// <returns>The new <see cref="Entity"/>.</returns>
    public static Entity CreateEntityStruct(int id, int world)
    {
#if PURE_ECS
        return new Entity(id, 0);
#else
        return new Entity(id, world);
#endif
    }

    /// <summary>
    ///     Creates an <see cref="EntityReference"/> struct and returns it.
    ///     Does not create an EntityReference, just the struct.
    /// </summary>
    /// <param name="id">Its id.</param>
    /// <param name="version">The version of the entity.</param>
    /// <param name="world">The world id. Unused if PURE_ECS is set.</param>
    /// <returns>The <see cref="EntityReference"/></returns>
    public static EntityReference CreateEntityReferenceStruct(int id, int version, int world)
    {
#if PURE_ECS
        var ent = new Entity(id, 0);
        return new EntityReference(ent, version);
#else
        var ent = new Entity(id, world);
        return new EntityReference(ent, version);
#endif
    }
}
