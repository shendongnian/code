    public static void InjectData<T>(this T data, Dictionary<Expression<Func<T, object>>, object> pairData) where T : IAuditable
    {
    	foreach (var item in pairData)
    	{
    		var member = item.Key;
    		// If member type is a reference type, then member.Body is the property accessor.
    		// For value types it is Convert(property accessor)
    		var memberBody = member.Body as MemberExpression ?? (MemberExpression)((UnaryExpression)member.Body).Operand;
            var lambda = Expression.Lambda<Action<T>>(Expression.Assign(memberBody, Expression.Constant(item.Value)), member.Parameters);
    		var action = lambda.Compile();
    		action(data);
    	}
    }
