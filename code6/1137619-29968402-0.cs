    public class DefaultVoidExpressionReplacer : ExpressionVisitor
    {
        public Expression To;
        protected override Expression VisitDefault(DefaultExpression node)
        {
            if (node.Type == typeof(void))
            {
                return this.Visit(To);
            }
            else
            {
                return base.VisitDefault(node);
            }
        }
    }
