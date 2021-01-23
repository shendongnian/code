    public IEnumerable<T> GetAllProjectTo<T>(params Expression<Func<TEntity, bool>>[] filters)
    {
        var query = Table.AsQueryable();
        if (filters != null)
        {
            query = filters.Aggregate(query, (current, where) => current.Where(where));
        }
    
        return query.Project().To<T>().AsEnumerable();
    }
