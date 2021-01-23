    /// <summary>
    /// This class replaces one parameter with another everywhere in a given expression tree.
    /// This is handy when you have two lambda expressions that you want to combine into one.
    /// </summary>
    public class ParameterReplacerVisitor : System.Linq.Expressions.ExpressionVisitor
    {
        private readonly ParameterExpression _originalParameter;
        private readonly ParameterExpression _newParameter;
        public ParameterReplacerVisitor(ParameterExpression originalParameter, ParameterExpression newParameter)
        {
            _originalParameter = originalParameter;
            _newParameter = newParameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _originalParameter)
            {
                node = _newParameter;
            }
            return base.VisitParameter(node);
        }
    }
