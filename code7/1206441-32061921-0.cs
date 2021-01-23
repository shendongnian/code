    public static class LinqExtensions 
    {
    	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, string name)
    	{
    		var properties = typeof(T).GetProperties();
    		var matchedProperty = properties.FirstOrDefault (p => p.Name == name);
    		if (matchedProperty == null)
    			throw new ArgumentException("name");
    			
    		var paramExpr = Expression.Parameter(typeof(T));
    		var propAccess = Expression.PropertyOrField(paramExpr, name);
    		
    		var expr = Expression.Lambda(propAccess, paramExpr);
    		var method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
    		var genericMethod = method.MakeGenericMethod(typeof(T), matchedProperty.PropertyType);		
    		return (IEnumerable<T>) genericMethod.Invoke(null, new object[] { query, expr.Compile() });
    	}
    }
