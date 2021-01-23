    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node.Method == methodToReplace)
        {
            var replacement = replacementFunction(
                node.Arguments.Select(StripNullable).ToList());
            if (replacement.Type != node.Type)
                return Expression.Convert(replacement, node.Type);
        }
        return base.VisitMethodCall(node);
    }
    private static Expression StripNullable(Expression e)
    {
        var unaryExpression = e as UnaryExpression;
        if (unaryExpression != null && e.NodeType == ExpressionType.Convert
            && unaryExpression.Operand.Type == Nullable.GetUnderlyingType(e.Type))
        {
            return unaryExpression.Operand;
        }
        return e;
    }
