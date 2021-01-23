    public static IQueryable<T> ApplySearch<T>(this IQueryable<T> queryable, SearchModel search) where T : class 
    {
        var predicates = new List<Expression<<Func<T, bool>>>();
        if (search != null)
        {
            if (search.PolicyNumber.HasValue && typeof (IPolicyNumber).IsAssignableFrom(queryable.ElementType))
                predicates.Add(SearchPredicates.ByPolicyNumber(search));
            if (search.UniqueId.HasValue && typeof (IUniqueId).IsAssignableFrom(queryable.ElementType))
                predicates.Add(SearchPredicates.ByUniqueId(search));
            if (!string.IsNullOrWhiteSpace(search.PostCode) && typeof(IPostCode).IsAssignableFrom(queryable.ElementType))
                predicates.Add(SearchPredicates.ByPostCode(search));
        }
        if (predicates.Count == 0)
            return queryable;
    
        var parameter = predicates[0].Parameters[0];
        var condition = predicates[0].Body;
        for (int i = 1; i < predicates.Count; i++)
            condition = Expression.Or(condition, predicates[i].Body.ReplaceParameter(predicates[i].Parameters[0], parameter));
        var predicate = Expression.Lambda<Func<T, bool>>(condition, parameter);
        return queryable.Where(predicate);
    }
