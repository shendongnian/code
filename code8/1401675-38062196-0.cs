    public static class QueryableExtensions
    {
    	public static IQueryable<T> OfType<T>(this IQueryable<T> source, IEnumerable<Type> types)
    	{
    		var parameter = Expression.Parameter(typeof(T), "a");
    		var body = types
    			.Select(type => Expression.TypeIs(parameter, type))
    			.Aggregate<Expression>(Expression.OrElse);
    		var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
    		return source.Where(predicate);
    	}
    }
