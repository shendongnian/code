    public bool Exists<TEntity>(params object[] keys)
        where TEntity : class
    {
        var dbSet = Set<TEntity>();
        var entity = dbSet.Find(keys);
        return entity != null;
    }
