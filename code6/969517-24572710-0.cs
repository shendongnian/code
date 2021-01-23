    private static Expression<Func<T, bool>> WhereById<T>(string id)
    {
        var pExpr = Expression.Parameter(typeof(T));
        var idExpr = Expression.Property(pExpr, "Id");
        var eqExpr = Expression.Equal(idExpr, Expression.Constant(id));
        return Expression.Lambda<Func<T, bool>>(eqExpr, pExpr);
    }
    
    private static IQueryable<T> FilterById<T>(string id, IQueryable<T> source)
    {
        if (!string.IsNullOrEmpty(queryCriteria.Id))
        {
            var whereExpr = WhereById<T>(string id);
            return source.Where(whereExpr);
        }
        return queryResults;
    }
    private static IQueryable<Class1> FilterClass1ResultsOnId(Class1QueryCriteria queryCriteria, IQueryable<Class1> queryResults)
    {
        return FilterById(queryCriteria.Id, queryResults);
    }
