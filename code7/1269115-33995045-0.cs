    object command = o.ToObject(commandType);
    MethodInfo dispatchMethod = GetMethod(() => _commandDispatcher.Dispatch<ICommand>(null))
        .GetGenericMethodDefinition()
        .MakeGenericMethod(commandType);
    RequestStatus result = (RequestStatus)dispatchMethod.Invoke(
        _commandDispatcher,
        new object[] { command });
    public static MethodInfo GetMethod<T1>(Expression<Action<T1>> methodSelector)
    {
        return GetMethodInfo(methodSelector);
    }
    private static MethodInfo GetMethodInfo(LambdaExpression methodSelector)
    {
        if (methodSelector == null)
        {
            throw new ArgumentNullException("methodSelector");
        }
        if (methodSelector.Body.NodeType != ExpressionType.Call)
        {
            throw new ArgumentOutOfRangeException(
                "methodSelector", 
                "Specified expression does is not a method call expression.");
        }
        var callExpression = (MethodCallExpression)methodSelector.Body;
        return callExpression.Method;
    }
