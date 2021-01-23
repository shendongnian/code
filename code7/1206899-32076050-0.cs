    public class Simplifier : ExpressionVisitor
    {
    	protected override Expression VisitConditional(ConditionalExpression node)
    	{
    		var test = Visit(node.Test);
    		var ifTrue = Visit(node.IfTrue);
    		var ifFalse = Visit(node.IfFalse);
    		
    		var testConst = test as ConstantExpression;
    		if(testConst != null)
    		{
    			var value = (bool) testConst.Value;
    			return value ? ifTrue : ifFalse;
    		}
    		
    		return Expression.Condition(test, ifTrue, ifFalse);
    	}
    	
    	protected override Expression VisitMember(MemberExpression node)
    	{
    		// Closed-over variables are represented as field accesses to fields on a constant object.
    		var field = (node.Member as FieldInfo);
    		var closure = (node.Expression as ConstantExpression);
    		if(closure != null)
    		{
    			var value = field.GetValue(closure.Value);
    			return VisitConstant(Expression.Constant(value));
    		}
    		return base.VisitMember(node);
    	}
    }
