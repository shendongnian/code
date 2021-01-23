	internal class ReplaceVisitor : ExpressionVisitor
	{
	    private readonly Dictionary<Expression, Expression> lookup;
	    public ReplaceVisitor(Dictionary<Expression, Expression> pairsToReplace)
	    {
	        lookup = pairsToReplace;
	    }
	    public override Expression Visit(Expression node)
	    {
	        if(lookup.ContainsKey(node))
	        	return base.Visit(lookup[node]);
        	else
        		return base.Visit(node);
	    }
	}
	
	public static Expression ReplaceAll(this Expression expression,
	    Dictionary<Expression, Expression> pairsToReplace)
	{
	    return new ReplaceVisitor(pairsToReplace).Visit(expression);
	}
	
	public static Expression ReplaceAll(this Expression expression,
	    IEnumerable<Tuple<Expression, Expression>> pairsToReplace)
	{
		var lookup = pairsToReplace.ToDictionary(pair => pair.Item1, pair => pair.Item2);
	    return new ReplaceVisitor(lookup).Visit(expression);
	}
