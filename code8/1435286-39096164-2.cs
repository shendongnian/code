    public TResult Execute<TResult>()// MyClass[] in this particular case
    {
        var myArray = new List<object>() { ... }; //actual type of those objects is MyClass
        Type genericArgument = typeof(TResult);
        if (!genericArgument.IsArray)
           // what do you want to return now???
        Type elementType = genericArgument.GetElementType();
        MethodInfo cast = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(elementType);
        MethodInfo toarray = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(elementType);
        object enumerable = cast.Invoke(null, new object[]{myArray});
        object array = toarray.Invoke(null, new object[]{enumerable});
        return (TResult)array;
    }
