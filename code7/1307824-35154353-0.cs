    public static class Utils
    {
    	public static IList<SelectListItem> ToSelectList<TSource, TValue>(this IQueryable<TSource> source, Expression<Func<TSource, TValue>> valueSelector, Expression<Func<TSource, string>> textSelector)
    	{
    		var itemValue = valueSelector.Body;
    		if (itemValue.Type != typeof(string))
    			itemValue = Expression.Call(itemValue, itemValue.Type.GetMethod("ToString", Type.EmptyTypes));
    		var itemText = textSelector.Body.ReplaceParameter(textSelector.Parameters[0], valueSelector.Parameters[0]);
    		var targetType = typeof(SelectListItem);
    		var selector = Expression.Lambda<Func<TSource, SelectListItem>>(
    			Expression.MemberInit(Expression.New(targetType),
    				Expression.Bind(targetType.GetProperty("Value"), itemValue),
    				Expression.Bind(targetType.GetProperty("Text"), itemText)
    			), valueSelector.Parameters);
    		return source.Select(selector).ToList();
    	}
    
    	static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
    	{
    		return new ParameterExpressionReplacer { source = source, target = target }.Visit(expression);
    	}
    
    	class ParameterExpressionReplacer : ExpressionVisitor
    	{
    		public ParameterExpression source;
    		public Expression target;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node == source ? target : base.VisitParameter(node);
    		}
    	}
    }
