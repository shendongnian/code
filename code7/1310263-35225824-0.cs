    public MyClass<object> ReturnWithDynamicParameterType(Type genericArgument)
    {
        Type genericType = typeof(MyClass<>).MakeGenericType(genericArgument);
        return (MyClass<object>)Activator.CreateInstance(genericType);
    }
