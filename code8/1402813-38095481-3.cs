    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereAny<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, bool>>> predicates)
    	{
    		if (predicates == null || !predicates.Any()) return source;
    		var predicate = predicates.Aggregate((a, b) => Expression.Lambda<Func<T, bool>>(
    			Expression.OrElse(a.Body, b.Body.ReplaceParameter(b.Parameters[0], a.Parameters[0])),
    			a.Parameters[0]));
    		return source.Where(predicate);
    	}
    }
