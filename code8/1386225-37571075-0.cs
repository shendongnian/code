    public static bool IsFlowerDescriptor(this Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(FlowerDescriptor<>))
            return true;
        if (type.BaseType != null)
            return type.BaseType.IsFlowerDescriptor();
            
        return false;
    }
