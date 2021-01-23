    void Main()
    {
    	var objects = new[] { new Test { Matter = "A" } }.AsQueryable();
    	var classes = objects.Where(
    		ExpressionExtensions.Query<Test>(q => q)
    		.Field("Matter")
    		.EndsWith("A")
    	);
    	classes.Expression.Dump();
    
    }
    
    public class Test
    {
    	public string Matter { get; set;}
    }
    
    public static class ExpressionExtensions
    {
    	public static Expression<Func<TElementType, TElementType>> Query<TElementType>(this Expression<Func<TElementType, TElementType>> expr)
    	{
    		return expr;
    	}
    
    	public static Expression<Func<TElementType, string>> Field<TElementType, TReturnType>(this Expression<Func<TElementType, TReturnType>> expr, string field)
    	{
    		Type entityType = typeof(TElementType);
    		PropertyInfo propertyInfo = entityType.GetProperty(field);
    		if (propertyInfo == null)
    			throw new ArgumentException(string.Format("{0} doesn't exist on {1}", field, entityType.Name));
    		ParameterExpression parameterExpression = Expression.Parameter(entityType, "e");
    		
    		return Expression.Lambda<Func<TElementType, string>>(
    			Expression.Property(parameterExpression, propertyInfo),
    			parameterExpression
    		);
    	}
    
    	public static Expression<Func<T, bool>> EndsWith<T, TReturnType>(this Expression<Func<T, TReturnType>> expr, string str)
    	{
    		var endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
    		var newBody = Expression.Call(expr.Body, endsWithMethod, Expression.Constant(str));
    		var result = Expression.Lambda<Func<T, bool>>(newBody, expr.Parameters);
    		return result;
    	}
    
    }
