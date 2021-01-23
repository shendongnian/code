    public static class ExpressionUtils
    {
        public static Expression<Func<T, bool>> MakePredicate<T>(
        	string memberPath, ExpressionType comparison, object value)
        {
        	var param = Expression.Parameter(typeof(T), "t");
        	var right = Expression.Constant(value);
        	var left = memberPath.Split('.').Aggregate((Expression)param, (target, memberName) =>
        	{
        		if (typeof(IEnumerable).IsAssignableFrom(target.Type))
        		{
        			var enumerableType = target.Type.GetInterfaces()
        				.Single(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        			return Expression.Call(typeof(Enumerable), memberName, enumerableType.GetGenericArguments(), target);
        		}
        		return Expression.PropertyOrField(target, memberName);
        	});
        	var body = Expression.MakeBinary(comparison, left, right);
        	return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }
