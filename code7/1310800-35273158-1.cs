    public static class QueryableUtils
    {
    	static Expression<Func<T, TResult>> Expr<T, TResult>(Expression<Func<T, TResult>> source) { return source; }
    
    	static MethodInfo GetMethod(this LambdaExpression source) { return ((MethodCallExpression)source.Body).Method; }
    
    	static readonly MethodInfo Object_ToString = Expr((object x) => x.ToString()).GetMethod();
    
    	static readonly MethodInfo String_Contains = Expr((string x) => x.Contains("y")).GetMethod();
    
    	public static IQueryable<T> Filter<T>(this IQueryable<T> query, List<SearchFilterDto> filters)
    	    // where T : BaseEntity
    	{
    		if (filters != null && filters.Count > 0 && !filters.Any(f => string.IsNullOrEmpty(f.Filter)))
    		{
    			var item = Expression.Parameter(query.ElementType, "item");
    			var body = filters.Select(f =>
    			{
    				// Process the member path and build the final value selector
    				Expression value = item;
    				foreach (var memberName in f.Column.Split('.'))
    				{
    					var member = item.Type.GetProperty(memberName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ??
    						(MemberInfo)item.Type.GetField(memberName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    					if (member == null) return null; // Should probably throw an error?
    					value = Expression.MakeMemberAccess(value, member);
    				}
    				// NOTE: "Safe" skipping invalid arguments is not a good practice.
    				// Without that requirement, the above block will be simply
    				// var value = f.Column.Split('.').Aggregate((Expression)item, Expression.PropertyOrField);
    				// Convert value to string if needed
    				if (value.Type != typeof(string))
    				{
    					// Here you can use different conversions based on the value.Type
    					// I'll just use object.ToString()
    					value = Expression.Call(value, Object_ToString);
    				}
    				// Finally build and return a call to string.Contains method
    				return (Expression)Expression.Call(value, String_Contains, Expression.Constant(f.Filter));
    			})
    			.Where(r => r != null)
    			.Aggregate(Expression.AndAlso);
    
    			var predicate = Expression.Lambda<Func<T, bool>>(body, item);
    			query = query.Where(predicate);
    		}
    		return query;
    	}
    }
