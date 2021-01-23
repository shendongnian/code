    public static IQueryable<Mammal> GetMammals(params Expression<Func<T, Object>>[] includeExps)
    {
         var query = context.Mammals.AsQueryable();
         if (includeExps != null)
            query = includeExps.Aggregate(query, (current, exp) => current.Include(exp));
    
         return query;
    
    }
