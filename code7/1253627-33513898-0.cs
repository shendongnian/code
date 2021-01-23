    internal class FindJoinsVisitor : ExpressionVisitor
    {
        private List<JoinExpression> expressions = new List<JoinExpression>();
        protected override Expression VisitJoin(JoinExpression join)
        {
            expressions.Add(join);
            return base.VisitJoin(join);
        }
        public IEnumerable<JoinExpression> JoinExpressions
        {
            get
            {
                return expressions;
            }
        }
    }
    public static IEnumerable<JoinExpression> FindJoins(
        this Expression expression)
    {
        var visitor = new FindJoinsVisitor();
        visitor.Visit(expression);
        return visitor.JoinExpressions;
    }
