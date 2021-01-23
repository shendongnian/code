    private static readonly Dictionary<ExpressionType, string> s_binaryOperators =
        new Dictionary<ExpressionType, string>
        {
            { ExpressionType.Equal, " == " },
            { ExpressionType.And, " AND " },
        };
    public static void ToString(Expression expression, StringBuilder builder)
    {
        switch (expression.NodeType)
        {
            case ExpressionType.Parameter:
                builder.Append(((ParameterExpression)expression).Name);
                break;
            case ExpressionType.Constant:
                builder.Append(((ConstantExpression)expression).Value);
                break;
            case ExpressionType.MemberAccess:
                var memberExpression = (MemberExpression)expression;
                // TODO: Add parentheses if memberExpression.Expression.NodeType
                // has lower precedence than the current expression.
                ToString(memberExpression.Expression, builder);
                builder.Append('.').Append(memberExpression.Member.Name);
                break;
            case ExpressionType.Equal:
            case ExpressionType.And:
                var binaryExpression = (BinaryExpression)expression;
                // TODO: Add parentheses if binaryExpression.Left.NodeType
                // has lower precedence than the current expression.
                ToString(binaryExpression.Left, builder);
                builder.Append(s_binaryOperators[expression.NodeType]);
                // TODO: Add parentheses if binaryExpression.Right.NodeType
                // has lower precedence than the current expression.
                ToString(binaryExpression.Right, builder);
                break;
            default:
                throw new NotImplementedException();
        }
    }
