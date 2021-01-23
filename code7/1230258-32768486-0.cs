    public IQueryable<TEntity> GetAll()
    {
        return _dbSet
            .Where(x => !x.IsDeleted)
            .OrderBy(x => x.Date);
    }
