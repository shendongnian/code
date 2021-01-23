    public static class ExpressionUtils
    {
    	public static Expression<Func<T, bool>> MakePredicate<T>(string memberPath, ExpressionType comparison, object value)
    	{
    		return (Expression<Func<T, bool>>)MakePredicate(
    			typeof(T), memberPath.Split('.'), 0, comparison, value);
    	}
    
    	static LambdaExpression MakePredicate(Type targetType, string[] memberNames, int index, ExpressionType comparison, object value)
    	{
    		var parameter = Expression.Parameter(targetType, targetType.Name.ToCamel());
    		Expression target = parameter;
    		for (int i = index; i < memberNames.Length; i++)
    		{
    			if (typeof(IEnumerable).IsAssignableFrom(target.Type))
    			{
    				var itemType = target.Type.GetInterfaces()
    					.Single(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
    					.GetGenericArguments()[0];
    				var itemPredicate = MakePredicate(itemType, memberNames, i, comparison, value);
    				return Expression.Lambda(
    					Expression.Call(typeof(Enumerable), "Any", new[] { itemType }, target, itemPredicate),
    					parameter);
    			}
    			target = Expression.PropertyOrField(target, memberNames[i]);
    		}
    		if (value != null && value.GetType() != target.Type)
    			value = Convert.ChangeType(value, target.Type);
    		return Expression.Lambda(
    			Expression.MakeBinary(comparison, target, Expression.Constant(value)),
    			parameter);
    	}
    
    	static string ToCamel(this string s)
    	{
    		if (string.IsNullOrEmpty(s) || char.IsLower(s[0])) return s;
    		if (s.Length < 2) return s.ToLower();
    		var chars = s.ToCharArray();
    		chars[0] = char.ToLower(chars[0]);
    		return new string(chars);
    	}
    }
