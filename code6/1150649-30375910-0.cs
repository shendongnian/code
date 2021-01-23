    public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
    {
        var query = DbSet.AsNoTracking();
    
        query = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return query;
    }
    MyGenericRepository<A>().GetAllIncluding(x=> x.B, x=> x.C).FirstOrDefault()
