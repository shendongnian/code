    public interface IVersionableDbObject<TEntity>
        where TEntity : class, IValidatableObject
    {
        byte[] Version { get; }
        Expression<Func<TEntity, bool>> LookupSelector { get; }
    }
