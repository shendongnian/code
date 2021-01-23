    public static class ExpressionUtils
    {
    	public static Expression ReplaceParemeter(this Expression expression, ParameterExpression source, Expression target)
    	{
    		return new ParameterReplacer { Source = source, Target = target }.Visit(expression);
    	}
    
    	class ParameterReplacer : ExpressionVisitor
    	{
    		public ParameterExpression Source;
    		public Expression Target;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node == Source ? Target : base.VisitParameter(node);
    		}
    	}
    }
