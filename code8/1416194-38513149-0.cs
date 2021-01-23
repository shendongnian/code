    public static class QueryableExtensions
    {
    	public static IQueryable<TResult> SelectTo<TResult>(this IQueryable source)
    	{
    		var sourceType = source.ElementType;
    		var resultType = typeof(TResult);
    		var parameter = Expression.Parameter(sourceType, "x");
    		var bindings =
    			from rm in resultType.GetProperties().Concat<MemberInfo>(resultType.GetFields())
    			join sm in sourceType.GetProperties().Concat<MemberInfo>(sourceType.GetFields())
    				on rm.Name equals sm.Name
    			select Expression.Bind(rm, Expression.MakeMemberAccess(parameter, sm));
    		var body = Expression.MemberInit(Expression.New(resultType), bindings);
    		return source.Provider.CreateQuery<TResult>(Expression.Call(
    			typeof(Queryable), "Select", new[] { sourceType, resultType },
    			source.Expression, Expression.Quote(Expression.Lambda(body, parameter))));
    	}
    }
