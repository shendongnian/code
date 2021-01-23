    internal class InjectConditionVisitor<T> : ExpressionVisitor
    {
    	private Expression<Func<T, bool>> queryCondition;
    
    	protected override Expression VisitMethodCall(MethodCallExpression node)
    	{
    		Expression expression = node;
    		if (node.Method.Name == "Include" || node.Method.Name == "IncludeSpan")
    		{
    			// DO something here! Let just add an OrderBy for fun
    
    			// LAMBDA: x => x.[PropertyName]
    			var parameter = Expression.Parameter(typeof(T), "x");
    			Expression property = Expression.Property(parameter, "ColumnInt");
    			var lambda = Expression.Lambda(property, parameter);
    
    			// EXPRESSION: expression.[OrderMethod](x => x.[PropertyName])
    			var orderByMethod = typeof(Queryable).GetMethods().First(x => x.Name == "OrderBy" && x.GetParameters().Length == 2);
    			var orderByMethodGeneric = orderByMethod.MakeGenericMethod(typeof(T), property.Type);
    			expression = Expression.Call(null, orderByMethodGeneric, new[] { expression, Expression.Quote(lambda) });
    		}
    		else
    		{
    			expression = base.VisitMethodCall(node);
    		}
    
    		return expression;
    	}
    }
