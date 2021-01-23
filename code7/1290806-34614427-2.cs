    public static Expression<Func<MyParentObject<T>, bool>> GetParentExpression<T>(Expression<Func<T, bool>> expression)
    {
    	Expression<Func<MyParentObject<T>, T>> item = parent => parent.Item;
    	var body = new ParameterExpressionReplacer { source = expression.Parameters[0], target = item.Body }.Visit(expression.Body);
    	var result = Expression.Lambda<Func<MyParentObject<T>, bool>>(body, item.Parameters);
    	return result;
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
