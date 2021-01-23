    public static class Utils
    {
    	public static Expression<Func<T, bool>> And<T>(List<Expression> expressions)
    	{
    		var first = (Expression<Func<T, bool>>)expressions[0];
    		if (expressions.Count == 1) return first;
    		var body = first.Body;
    		for (int i = 1; i < expressions.Count; i++)
    		{
    			var e = (Expression<Func<T, bool>>)expressions[i];
    			body = Expression.AndAlso(body, e.ReplaceParameter(e.Parameters[0], first.Parameters[0]));
    		}
    		return Expression.Lambda<Func<T, bool>>(body, first.Parameters);
    	}
    
    	static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
    	{
    		return new ParameterExpressionReplacer { source = source, target = target }.Visit(expression);
    	}
    
    	class ParameterExpressionReplacer : ExpressionVisitor
    	{
    		public ParameterExpression source;
    		public Expression target;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node == source ? target : base.VisitParameter(node);
    		}
    	}
    }
