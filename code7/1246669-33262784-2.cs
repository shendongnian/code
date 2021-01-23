    void SomeFunction<T>()
    {
        // ..............
        var returnObj = genericMethod.Invoke(_eventAggregator, null) as PubSubEvent<T>;
        returnObj?.Publish(data);
    }
    // call it like:
    // this is the type you want to pass.
    Type genericType = typeof(int);
    // get the MethodInfo
    var someFunctionMethodInfo = typeof(Program).GetMethod("SomeFunction", BindingFlags.Public);
    // create a generic from it
    var genericSomeFunctionMethodInfo = someFunctionMethodInfo.MakeGenericMethod(genericType);
    // invoke it.
    genericSomeFunctionMethodInfo.Invoke(null, new object[] { });
