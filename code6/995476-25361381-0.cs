    public static int GetFooCount()
    {
        return typeof(Bar).GetProperties()
            .Count(p => GetFooType(p.PropertyType) != null);
    }
    private static Type GetFooType(Type type)
    {
        while(type != null)
        {
            if (type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Foo<>))
                    return type.GetGenericArguments()[0];
            type = type.BaseType;
        }
        return null;
    }
