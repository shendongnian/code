    public static IPagedEntities<T> WithPaging<T>(this IOrderedQueryable<T> orderedQuery, int page, int pageSize)
    {
        var totalEntities = orderedQuery.Count();
    
        var entities = orderedQuery.Skip((page * pageSize)).Take(pageSize);
    
        return new PagedEntities<T>(page, pageSize, totalEntities, entities);
    }
