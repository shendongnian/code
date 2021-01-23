    public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeExpressions)
    {
        IDbSet<TEntity> dbSet = Context.Set<TEntity>();
        IQueryable<TEntity> query = null;
        foreach (var includeExpression in includeExpressions)
        {
            query = dbSet.Include(includeExpression);
        }
        return query ?? dbSet;
    }
