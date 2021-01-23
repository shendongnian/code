    public IQueryable<TEntity> All<TEntity> where TEntity : class
    {
        get
        {
            return _context.Set<TEntity>();
        }
    }
