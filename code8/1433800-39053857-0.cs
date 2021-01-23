    public static class QueryableExtensions
    {
    	public static IQueryable<T> Match<T>(this IQueryable<T> source, IEnumerable<T> target, Expression<Func<T, T, bool>> by)
    	{
    		var parameter = by.Parameters[0];
    		var condition = target
    			.Select(item => by.Body.ReplaceParameter(by.Parameters[1], Expression.Constant(item)))
    			.DefaultIfEmpty()
    			.Aggregate(Expression.OrElse) ?? Expression.Constant(false);
    		var predicate = Expression.Lambda<Func<T, bool>>(condition, parameter);
    		return source.Where(predicate);
    	}
    
    	public static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
    	{
    		return new ParameterReplacer { Source = source, Target = target }.Visit(expression);
    	}
    
    	class ParameterReplacer : ExpressionVisitor
    	{
    		public ParameterExpression Source;
    		public Expression Target;
    		protected override Expression VisitParameter(ParameterExpression node)
    		{
    			return node == Source ? Target : base.VisitParameter(node);
    		}
    	}
    }
