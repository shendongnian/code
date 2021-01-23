        internal sealed class VbComparisonTransform : ExpressionVisitor
        {
            protected override Expression VisitBinary(BinaryExpression node) {
                if (node == null)
                    throw new ArgumentNullException("node");
                if (node.Left.NodeType != ExpressionType.Call)
                    return base.VisitBinary(node);
                var callNode = node.Left as MethodCallExpression;
                if (callNode.Method.DeclaringType.FullName != "Microsoft.VisualBasic.CompilerServices.Operators")
                    return base.VisitBinary(node);
                if (callNode.Method.Name != "CompareString")
                    return base.VisitBinary(node);
                switch (node.NodeType) {
                    case ExpressionType.LessThan:
                        return Expression.LessThan(callNode.Arguments[0], callNode.Arguments[1]);
                    case ExpressionType.LessThanOrEqual:
                        return Expression.LessThanOrEqual(callNode.Arguments[0], callNode.Arguments[1]);
                    case ExpressionType.Equal:
                        return Expression.Equal(callNode.Arguments[0], callNode.Arguments[1]);
                    case ExpressionType.NotEqual:
                        return Expression.NotEqual(callNode.Arguments[0], callNode.Arguments[1]);
                    case ExpressionType.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(callNode.Arguments[0], callNode.Arguments[1]);
                    case ExpressionType.GreaterThan:
                        return Expression.GreaterThan(callNode.Arguments[0], callNode.Arguments[1]);
                    default:
                        string throwmessage = string.Format(CultureInfo.InvariantCulture, "VB.Net compare expression of type {0} not supported", node.NodeType);
                        throw new NotSupportedException(throwmessage);
                }
            }
        }
