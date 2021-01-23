    internal static class TypeExtensions
    {
        private static bool IsInheritedFromGenericTypeDefinition(Type type, Type baseType)
        {
            do
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == baseType)
                    return true;
                type = type.BaseType;
            }
            while (type != null);
            return false;
        }
        public static bool IsInheritedFrom(this Type type, Type baseType)
        {
            if (baseType.IsGenericTypeDefinition)
            {
                if (!type.IsInterface && baseType.IsInterface)
                {
                    do
                    {
                        // since baseType is an interface, and source type is not,
                        // we can't test inheritance tree anymore;
                        // instead, we have to obtain implemented interfaces and test them
                        var implementedInterfaces = type.GetInterfaces();
                        if (implementedInterfaces.Any(intf => IsInheritedFromGenericTypeDefinition(intf, baseType)))
                            return true;
                        type = type.BaseType;
                    }
                    while (type != null);
                    return false;
                }
                else
                    return IsInheritedFromGenericTypeDefinition(type, baseType);
            }
            return baseType.IsAssignableFrom(type);
        }
    }
