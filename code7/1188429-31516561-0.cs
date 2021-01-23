    public class MemberAccessVisitor : ExpressionVisitor
    {
        private readonly Type declaringType;
        private IList<string> propertyNames = new List<string>();
        public MemberAccessVisitor(Type declaringType)
        {
            this.declaringType = declaringType;
        }
        public IEnumerable<string> PropertyNames { get { return propertyNames; } }
        public override Expression Visit(Expression expr)
        {
            if (expr != null && expr.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpr = (MemberExpression)expr;
                if (memberExpr.Member.DeclaringType == declaringType)
                {
                    propertyNames.Add(memberExpr.Member.Name);
                }
            }
            return base.Visit(expr);
        }
    }
