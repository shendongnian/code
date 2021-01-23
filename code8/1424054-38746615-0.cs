    using System.Linq.Expressions;
    class ExpandSelectVisitor : ExpressionVisitor
    {
    	protected override Expression VisitMethodCall(MethodCallExpression node)
    	{
    		if (node.Method.DeclaringType == typeof(Enumerable) && node.Method.Name == "Select")
    			return Expression.Constant(Expression.Lambda(node).Compile().DynamicInvoke());
    		return base.VisitMethodCall(node);
    	}
    }
