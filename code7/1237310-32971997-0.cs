    public static IEnumerable<MethodInfo> GetMethods(Type type)
    {
        IEnumerable<MethodInfo> methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        if (type.BaseType != null)
        {
            methods = methods.Concat(GetMethods(type.BaseType));
        }
        return methods;
    }
