    public class ParameterUpdateVisitor : ExpressionVisitor
    {
        private ParameterExpression _parameter;
        public ParameterUpdateVisitor(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }
    }
