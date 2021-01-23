    public static Expression<Func<Resource, bool>> FilterResourcesByUserCriteria(FilterValue filterValueForUser)
    {
        //I assume you can write this part yourself.
    }
    
    public IQueryable<Resource> GetResources()
    {
        IQueryable<Resource> resources = _context.Resources;
        IEnumerable<FilterValue> filterValuesForUser  = GetFilterValues();
    
        IEnumerable<IQueryable<Resource>> queries = from filter in filterValuesForUser
                                                    let filterExp = FilterResourcesByUserCriteria(filter)
                                                    select resources.Where(filterExp);
        return Enumerable.Aggregate(queries, (l, r) => Queryable.Concat(l, r));
    
    }
