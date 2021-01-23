    public static class Utils
    {
    	public static Expression<Func<T, bool>> And<T>(List<Expression> expressions)
    	{
    		var item = Expression.Parameter(typeof(T), "item");
    		var body = expressions[0].GetPredicateExpression(item);
    		for (int i = 1; i < expressions.Count; i++)
    			body = Expression.AndAlso(body, expressions[i].GetPredicateExpression(item));
    		return Expression.Lambda<Func<T, bool>>(body, item);
    	}
    
    	static Expression GetPredicateExpression(this Expression target, ParameterExpression parameter)
    	{
    		var lambda = target as LambdaExpression;
    		var body = lambda != null ? lambda.Body : target;
    		return new ParameterBinder { value = parameter }.Visit(body);
    	}
    
    	class ParameterBinder : ExpressionVisitor
    	{
    		public ParameterExpression value;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node.Type == value.Type ? value : base.VisitParameter(node);
    		}
    	}
    }
