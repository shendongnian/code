    public static TFunc CreateAdapter<TFunc>(Type staticClass, string methodName)
    {
        var method = staticClass.GetMethod(methodName,
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
        var methodParameters = new ParameterExpression[parameterTypes.Length];
        for (int i = 0; i < parameterTypes.Length; i++)
        {
            methodParameters[i] = Expression.Parameter(parameterTypes[i], "p" + i);
        }
        var lambda = Expression.Lambda<TFunc>(
            Expression.Call(null, method, methodParameters), methodParameters);
        return lambda.Compile();
    }
