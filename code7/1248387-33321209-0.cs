    bool IsType(Type type)
    {
        TypeInfo info = typeof(Type).GetTypeInfo();
        return info.IsAssignableFrom(type.GetTypeInfo());
    }
