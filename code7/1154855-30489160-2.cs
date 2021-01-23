    public class MemberNullPropogationVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression == null || !IsNullable(node.Expression.Type))
                return base.VisitMember(node);
            var expression = base.Visit(node.Expression);
            var nullBaseExpression = Expression.Constant(null, expression.Type);
            var test = Expression.Equal(expression, nullBaseExpression);
            var memberAccess = Expression.MakeMemberAccess(expression, node.Member);
            var nullMemberExpression = Expression.Constant(null, node.Type);
            return Expression.Condition(test, nullMemberExpression, node);
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Object == null || !IsNullable(node.Object.Type))
                return base.VisitMethodCall(node);
            var expression = base.Visit(node.Object);
            var nullBaseExpression = Expression.Constant(null, expression.Type);
            var test = Expression.Equal(expression, nullBaseExpression);
            var memberAccess = Expression.Call(expression, node.Method);
            var nullMemberExpression = Expression.Constant(null, node.Type);
            return Expression.Condition(test, nullMemberExpression, node);
        }
        private static bool IsNullable(Type type)
        {
            if (type.IsClass)
                return true;
            return type.IsClass || type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
