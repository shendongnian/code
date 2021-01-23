    public static dynamic GetCalledMemberAndValidValues<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
    {
    	var methodCall = predicate.Body as MethodCallExpression;
    	Expression collectionExpression = null;
    	MemberExpression memberExpression = null;
    	if (methodCall != null && methodCall.Method.Name == "Contains")
    	{
    		if (methodCall.Method.DeclaringType == typeof(Enumerable))
    		{
    			collectionExpression = methodCall.Arguments[0];
    			memberExpression = methodCall.Arguments[1] as MemberExpression;
    		} else {
    			collectionExpression = methodCall.Object;
    			memberExpression = methodCall.Arguments[0] as MemberExpression;
    		}
    	}
    	
    	if (collectionExpression != null && memberExpression != null)
    	{
    		var lambda = Expression.Lambda<Func<object>>(collectionExpression, new ParameterExpression[0]);
    		var value = lambda.Compile()();
    		return new { parameterName = memberExpression.Member.Name, values = value };
    	} 
    	
    	return null;
    }
