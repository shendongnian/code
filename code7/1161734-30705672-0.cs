    public Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter = null)
    {
        IQueryable<T> query = DbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return query.ToListAsync();
    }
