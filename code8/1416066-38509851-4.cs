    public static Expression ReplaceParameter(this Expression expression,
        ParameterExpression toReplace,
        Expression newExpression)
    {
        return new ParameterReplaceVisitor(toReplace, newExpression)
            .Visit(expression);
    }
    public class ParameterReplaceVisitor : ExpressionVisitor
    {
        private ParameterExpression from;
        private Expression to;
        public ParameterReplaceVisitor(ParameterExpression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == from ? to : node;
        }
    }
