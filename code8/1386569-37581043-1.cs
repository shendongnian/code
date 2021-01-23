    public IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
    {
        IDbSet<TEntity> dbSet = Context.Set<TEntity>;
    
        IEnumerable<TEntity> query = null;
        foreach (var include in includes)
        {
            query = dbSet.Include(include);
        }
    
        return query ?? dbSet;
    }
