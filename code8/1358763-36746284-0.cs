    public static class EnumerableExtensions
    {
    	public static IEnumerable<T> Where<T>(this IEnumerable<T> source, IEnumerable<KeyValuePair<string, object>> filters)
    	{
    		if (filters == null || !filters.Any()) return source;
    		var parameter = Expression.Parameter(typeof(T), "x");
    		var body = filters
    			.Select(filter => Expression.Equal(
    				Expression.PropertyOrField(parameter, filter.Key),
    				Expression.Constant(filter.Value)))
    			.Aggregate(Expression.AndAlso);
    		var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
    		return source.Where(predicate.Compile());
    	}
    }
