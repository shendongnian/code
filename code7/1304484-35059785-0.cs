    class TestVisitor : ExpressionVisitor
    {
    	public Dictionary<Type, List<Tuple<MemberExpression, Expression>>> Result = new Dictionary<Type, List<Tuple<MemberExpression, Expression>>>();
    	Stack<Expression> stack = new Stack<Expression>();
    	public override Expression Visit(Expression node)
    	{
    		stack.Push(node);
    		base.Visit(node);
    		stack.Pop();
    		return node;
    	}
    	protected override Expression VisitMember(MemberExpression node)
    	{
    		if (node.Expression.NodeType != ExpressionType.Constant && (node.Type == typeof(string) || !typeof(IEnumerable).IsAssignableFrom(node.Type)))
    		{
    			var expression = stack.Skip(1).FirstOrDefault();
    			if (expression != null && expression.Type == typeof(bool))
    			{
    				List<Tuple<MemberExpression, Expression>> resultList;
    				if (!Result.TryGetValue(node.Expression.Type, out resultList))
    					Result.Add(node.Expression.Type, resultList = new List<Tuple<MemberExpression, Expression>>());
    				resultList.Add(Tuple.Create(node, expression));
    			}
    		}
    		return base.VisitMember(node);
    	}
    }
