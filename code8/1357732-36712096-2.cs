    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereEquals<T, TValue>(this IQueryable<T> source, Expression<Func<T, TValue>> selector, TValue value)
    	{
    		var predicate = Expression.Lambda<Func<T, bool>>(
    			Expression.Equal(selector.Body, Expression.Constant(value)),
    			selector.Parameters);
    		return source.Where(predicate);
    	}
    }
