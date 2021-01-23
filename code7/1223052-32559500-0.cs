    Dictionary<Type, Delegate> dict = new Dictionary<Type, Delegate>();
    void AddMethod(Type type, String methodName)
    {
        var method = type.GetMethod(methodName);
        var types = method.GetParameters().ConvertAll(p => p.ParameterType).ToList();
        if (method.IsStatic)
            types.Insert(0, type);
        types.Add(method.ReturnType);
        var delegType = Expression.GetFuncType(types.ToArray());
        var deleg = method.CreateDelegate(delegType);
        dict.Add(type, deleg);
    }
    object GetJobResult(object obj, params object[] additionalParams)
    {
        var paramList = additionalParams.ToList();
        paramList.Insert(0, obj);
        return dict[obj.GetType()].DynamicInvoke(paramList.ToArray());
    }
