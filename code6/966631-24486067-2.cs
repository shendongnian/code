    public T GetExp<T>(T obj)
    {
        Type type = typeof(T);
        if (type == typeof(int))
            return GetIntExp(obj);
        if (type == typeof(string))
            return GetStringExp(obj);
        if (type == typeof(double))
            return GetDoubleExp(obj);
        if (type == typeof(DateTime))
            return GetDateExp(obj);
        if (type == typeof(APIObject))
            return GetAPIObjectExp(obj);
        throw new Exception("Invalid Type");
    }
