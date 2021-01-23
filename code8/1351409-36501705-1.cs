    public class ParameterRebinder : ExpressionVisitor
    {
    	private readonly Dictionary<ParameterExpression, ParameterExpression> Map;
    
    	public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
    	{
    		this.Map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
    	}
    
    	public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
    	{
    		return new ParameterRebinder(map).Visit(exp);
    	}
    
    	protected override Expression VisitParameter(ParameterExpression node)
    	{
    		ParameterExpression replacement;
    		if (this.Map.TryGetValue(node, out replacement))
    		{
    			return replacement;
    			//return this.Visit(replacement);
    		}
    		return base.VisitParameter(node);
    	}
    }
