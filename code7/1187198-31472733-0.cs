    public static class ExpressionExtensions
    {
    	public static string GetMemberName<T>(this Expression<Func<T, object>> expression)
    	{
    		return GetMemberName(expression.Body);
    	}
    
    	public static string GetMemberName (this Expression propertyExpression)
    	{
    		var lambda = propertyExpression as LambdaExpression;
    		MemberExpression memberExpression = null;
    
    		if (propertyExpression is UnaryExpression)
    		{
    			var unaryExpression = propertyExpression as UnaryExpression;
    			memberExpression = unaryExpression.Operand as MemberExpression;
    		}
    		else if (lambda != null && lambda.Body is UnaryExpression)
    		{
    			var unaryExpression = lambda.Body as UnaryExpression;
    			memberExpression = unaryExpression.Operand as MemberExpression;
    		}
    		else if (lambda != null)
    		{
    			memberExpression = lambda.Body as MemberExpression;
    		}
    		else
    		{
    			var expression = propertyExpression as MemberExpression;
    			if (expression != null)
    				memberExpression = expression;
    		}
    
    		if (memberExpression == null) return null;
    
    		var propertyInfo = memberExpression.Member;
    
    		return propertyInfo.Name;
    	}
    }
