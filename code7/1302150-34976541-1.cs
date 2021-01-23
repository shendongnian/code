    internal class InjectConditionVisitor<T> : ExpressionVisitor
    {
    	private Expression<Func<T, bool>> queryCondition;
    
    	protected override Expression VisitMethodCall(MethodCallExpression node)
    	{
    		if (node.Method.Name == "IncludeSpan")
    		{
    			// DO something here!
    		}
    
    		return base.VisitMethodCall(node);
    	}
    
    	public IQueryable<T> VisitInclude(IQueryable<T> query)
    	{
    		var expression = Visit(query.Expression);
    
    		if (expression != query.Expression)
    		{
    			query = query.Provider.CreateQuery<T>(expression);
    		}
    		return query;
    	} 
    }
