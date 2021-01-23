    private static object Create(Type genericType, params Type[] genericArguments)
    {
        Type genericClass = genericType.MakeGenericType(genericArguments);
        return Activator.CreateInstance(genericClass);
    }
