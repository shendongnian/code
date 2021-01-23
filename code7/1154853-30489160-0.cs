    public class MemberNullPropogationVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression == null)
                return base.VisitMember(node);
            var expression = base.Visit(node.Expression);
            var nullExpression = Expression.Constant(null, expression.Type);
            var test = Expression.Equal(expression, nullExpression);
            var memberAccess = Expression.MakeMemberAccess(expression, node.Member);
            return Expression.Condition(test, nullExpression, node);
        }
    }
