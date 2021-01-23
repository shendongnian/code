    public static class Utils
    {
    	public static Expression<Func<T, TResult>> Expr<T, TResult>(Expression<Func<T, TResult>> e) { return e; }
    
    	public static Expression<Func<TOuter, TResult>> Bind<TOuter, TInner, TResult>(this Expression<Func<TOuter, TInner>> source, Expression<Func<TInner, TResult>> resultSelector)
    	{
    		var body = resultSelector.Body.ReplaceParameter(resultSelector.Parameters[0], source.Body);
    		return Expression.Lambda<Func<TOuter, TResult>>(body, source.Parameters);
    	}
    
    	public static Expression<Func<TSource, TTarget>> BindMemberInit<TSource, TTarget, TMember, TValue>(this Expression<Func<TSource, TTarget>> expression, Expression<Func<TTarget, TMember>> member, Expression<Func<TSource, TValue>> value)
    	{
    		var binding = Expression.Bind(
    			((MemberExpression)member.Body).Member,
    			value.Body.ReplaceParameter(value.Parameters[0], expression.Parameters[0]));
    		var body = (MemberInitExpression)expression.Body;
    		return expression.Update(body.Update(body.NewExpression, body.Bindings.Concat(new[] { binding })), expression.Parameters);
    	}
    
    	static Expression ReplaceParameter(this Expression expression, ParameterExpression source, Expression target)
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
