    public IDbSetWrapper<TEntity> GetSet<TEntity>()
        where TEntity : class
    {
        var type = typeof(MyDbSetWrapper<>).MakeGenericType(typeof(TEntity));
        return (MyDbSetWrapper<TEntity>) Activator.CreateInstance(type);
    }
