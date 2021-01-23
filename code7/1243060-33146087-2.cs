    public static void InjectData<T>(this T data, Dictionary<Expression<Func<T, object>>, object> pairData) //where T : IAuditable
    {
    	var assignments = new List<Expression>();
    	foreach (var item in pairData)
    	{
    		var member = item.Key;
    		// If member type is a reference type, then member.Body is the property accessor.
    		// For value types it is Convert(property accessor)
    		var memberBody = member.Body as MemberExpression ?? (MemberExpression)((UnaryExpression)member.Body).Operand;
    		assignments.Clear();
    		assignments.Add(Expression.Assign(memberBody, Expression.Constant(item.Value)));
            var target = member.Parameters[0];
    		while (memberBody.Expression != target)
    		{
    			var childMember = (MemberExpression)memberBody.Expression;
    			assignments.Add(Expression.IfThen(Expression.ReferenceEqual(childMember, Expression.Constant(null)),
    				Expression.Assign(childMember, Expression.New(childMember.Type))));
    			memberBody = childMember;
    		}
    		assignments.Reverse();
    		var body = assignments.Count > 1 ? Expression.Block(assignments) : assignments[0];
            var lambda = Expression.Lambda<Action<T>>(body, target);
    		var action = lambda.Compile();
    		action(data);
    	}
    }
