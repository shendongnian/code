    public class ParameterRewriter<TArg, TReturn> : ExpressionVisitor
    {
    	Dictionary<ParameterExpression, ParameterExpression> _mapping;
    	public Expression<Func<TArg, TReturn>> Rewrite(Expression<Func<TArg, TReturn>> expr, Dictionary<ParameterExpression, ParameterExpression> mapping)
    	{
    		_mapping = mapping;
    		return (Expression<Func<TArg, TReturn>>)Visit(expr);
    	}
    
    	protected override Expression VisitParameter(ParameterExpression p)
    	{
    		if (_mapping.ContainsKey(p))
    			return _mapping[p];
    		return p;
    	}
    }
