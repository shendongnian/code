    public static class DynamicQueryableEx
    {
    	public static IQueryable<T> Select<T>(this IQueryable source, string selector)
    	{
    		var dynamicLambda = System.Linq.Dynamic.DynamicExpression.ParseLambda(source.ElementType, null, selector);
    		var memberInit = dynamicLambda.Body as MemberInitExpression;
    		if (memberInit == null) throw new InvalidOperationException();
    		var projectType = typeof(T);
    		var bindings = memberInit.Bindings.Cast<MemberAssignment>()
    			.Select(mb => Expression.Bind(
    				(MemberInfo)projectType.GetProperty(mb.Member.Name) ??
    				projectType.GetField(mb.Member.Name), mb.Expression));
    		var body = Expression.MemberInit(Expression.New(projectType), bindings);
    		var lambda = Expression.Lambda(body, dynamicLambda.Parameters);
    		return source.Provider.CreateQuery<T>(
    			Expression.Call(
    				typeof(Queryable), "Select",
    				new Type[] { source.ElementType, lambda.Body.Type },
    				source.Expression, Expression.Quote(lambda)));
    	}
    }
