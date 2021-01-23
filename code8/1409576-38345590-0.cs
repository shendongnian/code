    public static Func<TTarget, bool> Convert<TSource, TTarget>(Expression<Func<TSource, bool>> root)
    {
        var visitor = new ParameterTypeVisitor<TSource, TTarget>();
        var expression = (Expression<Func<TTarget, bool>>)visitor.Visit(root);
        return expression.Compile();
    }
    
	public class ParameterTypeVisitor<TSource, TTarget> : ExpressionVisitor
    {
        private ReadOnlyCollection<ParameterExpression> _parameters;
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameters?.FirstOrDefault(p => p.Name == node.Name) ?? 
                (node.Type == typeof(TSource) ? Expression.Parameter(typeof(TTarget), node.Name) : node);
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _parameters = VisitAndConvert<ParameterExpression>(node.Parameters, "VisitLambda");
            return Expression.Lambda(Visit(node.Body), _parameters);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                return Expression.Property(Visit(node.Expression), node.Member.Name);
            }
            return base.VisitMember(node);
        }
    }
