    public static class ExpressionUtils
    {
    	public static Expression<Func<TOuter, TResult>> Bind<TOuter, TInner, TResult>(this Expression<Func<TOuter, TInner>> source, Expression<Func<TInner, TResult>> resultSelector)
    	{
    		var body = new ParameterExpressionReplacer { source = resultSelector.Parameters[0], target = source.Body }.Visit(resultSelector.Body);
    		var lambda = Expression.Lambda<Func<TOuter, TResult>>(body, source.Parameters);
    		return lambda;
    	}
    
    	public static Expression<Func<TOuter, TResult>> ApplyTo<TInner, TResult, TOuter>(this Expression<Func<TInner, TResult>> source, Expression<Func<TOuter, TInner>> innerSelector)
    	{
    		return innerSelector.Bind(source);
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
