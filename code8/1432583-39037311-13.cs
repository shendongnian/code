    private class PredicateRewriterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _parameterExpression;
        public PredicateRewriterVisitor(ParameterExpression parameterExpression)
        {
            _parameterExpression = parameterExpression;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameterExpression;
        }
    }
