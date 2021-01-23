    public static Type GetNonProxiedType(this object obj)
    {
        return obj.GetType().GetNonProxiedType();
    }
    public static Type GetNonProxiedType(this Type type)
    {
        return IsProxied(type) ? type.BaseType : type;
    }
    public static bool IsProxied(this Type type)
    {
        return type.Namespace.Contains("Proxies");
    }
