    public Type GetNullableTypeFrom(Type type)
    {
        if (!type.IsValueType || type.IsGenericType)
            return type;
    
        var nullableType = typeof(Nullable<>).MakeGenericType(type);
    
        return nullableType;
    }
