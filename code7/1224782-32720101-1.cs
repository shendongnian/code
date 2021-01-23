    /// <summary>
    /// Creates a method with one parameter of type TParam
    /// </summary>
    private static Action<object, TParam> CreateMethod<TParam>(Type targetType, string methodName)
    {
        MethodInfo methodInfo = targetType.GetMethod(methodName, new Type[] { typeof(TParam) });
    
        ParameterExpression instance = Expression.Parameter(typeof(object), "inst");
        ParameterExpression msg = Expression.Parameter(typeof(TParam), "p");
        Expression callExpression = Expression.Call(
            Expression.Convert(instance, targetType),
            methodInfo,
            msg);
        Expression<Action<object, TParam>> methodExpression = Expression.Lambda<Action<object, TParam>>(callExpression, instance, msg);
        Action<object, TParam> method = methodExpression.Compile();
        return method;
    }
    
    /// <summary>
    /// Creates a getter with the return type TReturn
    /// </summary>
    private static Func<object, TReturn> CreateGetter<TReturn>(Type targetType, string propertyName)
    {
        PropertyInfo propertyInfo = targetType.GetProperty(propertyName);
    
        ParameterExpression instance = Expression.Parameter(typeof(object), "inst");
        Expression callExpression = Expression.Property(
            Expression.Convert(instance, targetType),
            propertyInfo);
        Expression<Func<object, TReturn>> methodExpression = Expression.Lambda<Func<object, TReturn>>(callExpression, instance);
        Func<object, TReturn> property = methodExpression.Compile();
        return property;
    }
