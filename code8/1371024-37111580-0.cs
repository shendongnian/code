    public static class Extensions
    {
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> one, Expression<Func<T, bool>> another)
        {
            var parameter = one.Parameters[0];
            var visitor = new ReplaceParameterVisitor(parameter);
            another = (Expression<Func<T, bool>>)visitor.Visit(another);
            var body = Expression.Or(one.Body, another.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
    class ReplaceParameterVisitor : ExpressionVisitor
    {
        public ParameterExpression NewParameter { get; private set; }
        public ReplaceParameterVisitor(ParameterExpression newParameter)
        {
            this.NewParameter = newParameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this.NewParameter;
        }
    }
