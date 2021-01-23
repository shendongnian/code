    object obj = new Wrapper<SomeOtherClass> { Data = new SomeOtherClass { WrappedData = "Hello" } };
    Type type = obj.GetType();
    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Wrapper<>))
    {
        dynamic data = ((dynamic)obj).Data;
        dynamic wrappedData = data.WrappedData;
    }
