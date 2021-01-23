    public static class Extensions
    {
    	public static IQueryable<T> Select<T>(this IQueryable source, string[] fields)
    	{
    		var parameter = Expression.Parameter(source.ElementType, "o");
    		var body = Expression.MemberInit(
    			Expression.New(typeof(T)),
    			fields.Select(field => Expression.Bind(
    				typeof(T).GetProperty(field),
    				Expression.PropertyOrField(parameter, field))
    			)
    		);
    		var selector = Expression.Lambda(body, parameter);
    		var expression = Expression.Call(
    			typeof(Queryable), "Select", new[] { parameter.Type, body.Type },
    			source.Expression, Expression.Quote(selector)
    		);
    		return source.Provider.CreateQuery<T>(expression);
    	}
    	public static IEnumerable<string> Serialize<T>(this IEnumerable<T> source, string separator)
    	{
    		var properties = typeof(T).GetProperties();
    		return source.Select(item => string.Join(separator, properties.Select(property => property.GetValue(item))));
    	}
    }
