    public static Repository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity
    {
        Type repositoryType = typeof(Repository<>).MakeGenericType(typeof(TEntity));
        return (Repository<TEntity>)Activator.CreateInstance(repositoryType);
    }
