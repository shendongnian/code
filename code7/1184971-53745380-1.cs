    void Test(Expression<Func<string>> expression)
    {
        if (expression.Body.NodeType == ExpressionType.Call)
        {
            var callExpression = (MethodCallExpression)expression.Body;
            var getMethod = callExpression.Method;
            var indexer = getMethod.DeclaringType.GetProperties()
                .FirstOrDefault(p => p.GetGetMethod() == getMethod);
            if (indexer == null)
            {
                // Not indexer access
            }
            else
            {
                // indexer is a PropertyInfo accessed by expression
            }
        }
    }
