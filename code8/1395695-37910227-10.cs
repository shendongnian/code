    public static IQueryable<T> ApplySearch<T>(this IQueryable<T> queryable, SearchModel search) where T : class 
    {
        var subQueries = new List<IQueryable<T>>();
        if (search != null)
        {
            if (search.PolicyNumber.HasValue && typeof (IPolicyNumber).IsAssignableFrom(queryable.ElementType))
            {
                subQueries.Add(queryable.SearchByPolicyNumber(search));
            }
    
            if (search.UniqueId.HasValue && typeof (IUniqueId).IsAssignableFrom(queryable.ElementType))
            {
                subQueries.Add(queryable.SearchByUniqueId(search));
            }
    
            if (!string.IsNullOrWhiteSpace(search.PostCode) && typeof(IPostCode).IsAssignableFrom(queryable.ElementType))
            {
                subQueries.Add(queryable.SearchByPostCode(search));
            }
        }
    
        return subQueries.DefaultIfEmpty(queryable)
            .Aggregate((a, b) => a.Union(b));
    }
