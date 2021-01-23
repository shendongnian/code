    public static class ExpressionUtils
    {
    	public static Expression<Func<TTarget, bool>> ConvertTo<TSource, TTarget>(this Expression<Func<TSource, bool>> source, Expression<Func<TTarget, TSource>> sourceSelector)
    	{
    		var body = new ParameterExpressionReplacer { source = source.Parameters[0], target = sourceSelector.Body }.Visit(source.Body);
    		var lambda = Expression.Lambda<Func<TTarget, bool>>(body, sourceSelector.Parameters);
    		return lambda;
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
