    // T is the entity type, TProp is the poperty type
    private static Func<T, TProp> Getter<T, TProp>(string propertyName)
    {
        Type entityType = typeof(T);
        PropertyInfo propertyInfo = entityType.GetProperty(propertyName);
    
        var getterMethodInfo = propertyInfo.GetGetMethod();
        var entity = Expression.Parameter(entityType);
        var getterCall = Expression.Call(entity, getterMethodInfo);
                    
        var lambda = Expression.Lambda(getterCall, entity);
        var functionThatGetsValue = (Func<T, TProp>)lambda.Compile();
                    
        return functionThatGetsValue; 
    }
