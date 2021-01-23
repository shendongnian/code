    public T SatisfyingItemFrom(IQueryable<T> query)
    {
        return Sort(query).Where(Predicate).SingleOrDefault();
    }
    public IQueryable<T> SatisfyingItemsFrom(IQueryable<T> query)
    {
        return Sort(query).Where(Predicate);
    }
