    public class MyVisitor : ExpressionVisitor
    {
        public bool HasOrderBy { get; private set; }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof (Queryable) &&
                (node.Method.Name == "OrderBy" || node.Method.Name == "OrderByDescending"))
                HasOrderBy = true;
            return base.VisitMethodCall(node);
        }
    }
