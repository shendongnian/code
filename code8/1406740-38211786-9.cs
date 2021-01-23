    public static Repository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity
    {
        if (typeof(TEntity) == typeof(Customer))
            return (Repository<TEntity>)(object)new Repository<Customer>();
        if (typeof(TEntity) == typeof(Product))
            return (Repository<TEntity>)(object)new Repository<Product>();
        throw new Exception("Entity of type " + typeof(IEntity).Name + " is not supported.");
    }
