    public class WhereVisitor : ExpressionVisitor
    {
        private static bool _filter;
        private static WhereVisitor _visitor = new WhereVisitor();
        private WhereVisitor() { }
        public new static bool Visit(Expression expression)
        {
            _filter = false;
            //Cast to ExpressionVisitor to use the default Visit and not our new one
            ((ExpressionVisitor)_visitor).Visit(expression);
            return _filter;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Where")
                _filter = true;
            return base.VisitMethodCall(node);
        }
    }
