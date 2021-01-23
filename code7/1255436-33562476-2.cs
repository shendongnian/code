    static bool IsPredefinedType(Type type)
    {
        if (_predefinedTypes.Contains(type)) return true;
        
        if (GlobalConfig.CustomTypeProvider.GetCustomTypes().Contains(type)) return true;
        
        // for generic type check GenericTypeDefinition
        if (type.IsGenericType && GlobalConfig.CustomTypeProvider.GetCustomTypes().Contains(type.GetGenericTypeDefinition())) return true;
        return false;
    }
