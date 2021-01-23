    public static class DynamicQueryableEx
    {
    	public static IQueryable<TResult> Select<TResult>(this IQueryable source, string selector, params object[] values)
    	{
    		if (source == null) throw new ArgumentNullException("source");
    		if (selector == null) throw new ArgumentNullException("selector");
    		var dynamicLambda = System.Linq.Dynamic.DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
    		var memberInit = dynamicLambda.Body as MemberInitExpression;
    		if (memberInit == null) throw new NotSupportedException();
    		var resultType = typeof(TResult);
    		var bindings = memberInit.Bindings.Cast<MemberAssignment>()
    			.Select(mb => Expression.Bind(
    				(MemberInfo)resultType.GetProperty(mb.Member.Name) ?? resultType.GetField(mb.Member.Name),
    				mb.Expression));
    		var body = Expression.MemberInit(Expression.New(resultType), bindings);
    		var lambda = Expression.Lambda(body, dynamicLambda.Parameters);
    		return source.Provider.CreateQuery<TResult>(
    			Expression.Call(
    				typeof(Queryable), "Select",
    				new Type[] { source.ElementType, lambda.Body.Type },
    				source.Expression, Expression.Quote(lambda)));
    	}
    }
