    public interface IRepository<TEntity> where TEntity : class
    {
        IIncludableJoin<TEntity, TProperty> Join<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
        ...
    }
