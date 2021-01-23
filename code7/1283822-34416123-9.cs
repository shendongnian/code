    public static class ExpressionHelpers
    {
    	public static Expression InlineInvokes<T>(this T expression)
    		where T : Expression
    	{
    		return (T)new InvokeInliner().Inline(expression);
    	}
    
    	public static Expression InlineInvokes(this InvocationExpression expression)
    	{
    		return new InvokeInliner().Inline(expression);
    	}
    
    	public class InvokeInliner : ExpressionVisitor
    	{
    		private Stack<Dictionary<ParameterExpression, Expression>> _context = new Stack<Dictionary<ParameterExpression, Expression>>();
    		public Expression Inline(Expression expression)
    		{
    			return Visit(expression);
    		}
    
    		protected override Expression VisitInvocation(InvocationExpression e)
    		{
    			var callingLambda = ((LambdaExpression)e.Expression);
    			var currentMapping = new Dictionary<ParameterExpression, Expression>();
    			for (var i = 0; i < e.Arguments.Count; i++)
    			{
    				var argument = Visit(e.Arguments[i]);
    				var parameter = callingLambda.Parameters[i];
    				if (parameter != argument)
    					currentMapping.Add(parameter, argument);
    			}
    			_context.Push(currentMapping);
    			var result = Visit(callingLambda.Body);
    			_context.Pop();
    			return result;
    		}
    
    		protected override Expression VisitParameter(ParameterExpression e)
    		{
    			if (_context.Count > 0)
    			{
    				var currentMapping = _context.Peek();
    				if (currentMapping.ContainsKey(e))
    					return Visit(currentMapping[e]);
    			}
    			return e;
    		}
    	}
    }
