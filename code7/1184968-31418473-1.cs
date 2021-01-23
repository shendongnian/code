    public class PropertyFixerVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name.StartsWith("get_"))
            {
                var possibleProperty = node.Method.Name.Substring(4);
                var properties = node.Method.DeclaringType.GetProperties()
                    .Where(p => p.Name == possibleProperty);
                //HACK: need to filter out for overriden properties, multiple parameter choices, etc.
                var property = properties.FirstOrDefault();
                if (property != null)
                    return Expression.Property(node.Object, possibleProperty, node.Arguments.ToArray());
                return base.VisitMethodCall(node);
                    
            }
            else
                return base.VisitMethodCall(node);
        }
    }
