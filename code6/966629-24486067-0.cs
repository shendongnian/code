    public T GetExp<T>(T obj) where T : new()
    {
        Type type = typeof(T);
        if (type == typeof(integer))
            return GetIntExp(obj);
        if (type == typeof(string))
            return GetStringExp(obj);
        if (type == typeof(double))
            return GetDoubleExp(obj);
        if (type == typeof(DatTime))
            return GetDateExp(obj);
        if (type == typeof(APIObject))
            return GetAPIObjectExp(obj);
        return new T();
    }
