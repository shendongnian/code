    public static class ExpressionUtils
    {
    	public static Expression<TDelegate> ReplaceVariablesWithConstants<TDelegate>(this Expression<TDelegate> source)
    	{
    		return source.Update(
    			new ReplaceVariablesWithConstantsVisitor().Visit(source.Body), 
    			source.Parameters);
    	}
    
    	class ReplaceVariablesWithConstantsVisitor : ExpressionVisitor
    	{
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			var expression = Visit(node.Expression);
    			if (expression is ConstantExpression)
    			{
    				var variable = ((ConstantExpression)expression).Value;
    				var value = node.Member is FieldInfo ?
    					((FieldInfo)node.Member).GetValue(variable) :
    					((PropertyInfo)node.Member).GetValue(variable);
    				return Expression.Constant(value, node.Type);
    			}
    			return node.Update(expression);
    		}
    	}
    }
