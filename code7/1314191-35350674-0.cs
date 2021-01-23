    public static class ExpressionUtils
    {
    	public static Expression<Func<TTarget, bool>> Convert<TSource, TTarget>(Expression<Func<TSource, bool>> source)
    	{
    		var parameter = Expression.Parameter(typeof(TTarget), source.Parameters[0].Name);
    		var body = new ParameterConverter { source = source.Parameters[0], target = parameter }.Visit(source.Body);
    		return Expression.Lambda<Func<TTarget, bool>>(body, parameter);
    	}
    
    	class ParameterConverter : ExpressionVisitor
    	{
    		public ParameterExpression source;
    		public ParameterExpression target;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node == source ? target : base.VisitParameter(node);
    		}
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			return node.Expression == source ? Expression.PropertyOrField(target, node.Member.Name) : base.VisitMember(node);
    		}
    	}
    }
