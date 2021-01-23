    private IQueryable<T> Prepare(IQueryable<T> query) 
    {
        var filtered = query.Where(Predicate);
        var sorted = Sort(filtered);
        var postProcessed = PostProcess(sorted);
        return postProcessed;
    }
    public T SatisfyingItemFrom(IQueryable<T> query)
    {
        return Prepare(query).SingleOrDefault();
    }
    public IQueryable<T> SatisfyingItemsFrom(IQueryable<T> query)
    {
        return Prepare(query);
    }
