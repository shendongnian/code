    public class SuperHack : ExpressionVisitor
    {	
    	private Dictionary<ParameterExpression, LambdaExpression> _replacements;
    	private ParameterExpression _newParameter;
    	public SuperHack(Dictionary<ParameterExpression, LambdaExpression> replacements, ParameterExpression newParameter)
    	{
    		_replacements = replacements ?? new Dictionary<ParameterExpression, LambdaExpression>();
    		_newParameter = newParameter;
    	}
    
    	public Expression Modify(Expression expression)
    	{
    		var res = Visit(expression);
    		return res;
    	}
    	
    	protected override Expression VisitLambda<T>(Expression<T> e)
    	{
    		return Expression.Lambda(Visit(e.Body), _newParameter);
    	}
    	
    	protected override Expression VisitParameter(ParameterExpression e)
    	{
    		if (_replacements.ContainsKey(e))
    			return Visit(Expression.Lambda(_replacements[e].Body, _newParameter).Body);
    		
    		return base.VisitParameter(_newParameter);
    	}
    }
