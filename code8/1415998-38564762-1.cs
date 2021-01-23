    public static class QueryableExtensions
    {
    	public static IQueryable<TResult> Select<TResult>(this IQueryable source, string[] columns)
    	{
    		var sourceType = source.ElementType;
    		var resultType = typeof(TResult);
    		var parameter = Expression.Parameter(sourceType, "e");
    		var bindings = columns.Select(column => Expression.Bind(
    			resultType.GetProperty(column), Expression.PropertyOrField(parameter, column)));
    		var body = Expression.MemberInit(Expression.New(resultType), bindings);
    		var selector = Expression.Lambda(body, parameter);
    		return source.Provider.CreateQuery<TResult>(
    			Expression.Call(typeof(Queryable), "Select", new Type[] { sourceType, resultType },
    				source.Expression, Expression.Quote(selector)));
    	}
    }
