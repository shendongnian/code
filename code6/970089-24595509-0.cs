    private static void Subscribe<TEventArgs>(Expression<Func<Action<object, TEventArgs>>> expression)
    {
        var accessor = ((MethodCallExpression)((UnaryExpression)expression.Body).Operand).Arguments[1];
        var handlerFunc = Expression.Lambda<Func<object>>(accessor).Compile();
        var handler = handlerFunc();
        // handler now contains the instance you're interested in
    }
