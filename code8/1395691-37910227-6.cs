    public static IQueryable<T> SearchByPolicyNumber<T>(this IQueryable<T> queryable, SearchModel search) where T : class 
    {
        return queryable.Where(x => predicate_using_PolicyNumber(x, search));
    }
    
    public static IQueryable<T> SearchByUniqueId<T>(this IQueryable<T> queryable, SearchModel search) where T : class 
    {
        return queryable.Where(x => predicate_using_UniqueId(x, search));
    }
    
    public static IQueryable<T> SearchByPostCode<T>(this IQueryable<T> queryable, SearchModel search) where T : class 
    {
        return queryable.Where(x => predicate_using_PostCode(x, search));
    }
