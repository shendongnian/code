    // your type
    var type = typeof(Impl);
    // find specific interface on your type
    var interfaceType = type.GetInterfaces()
        .Where(x=>x.GetGenericTypeDefinition() == typeof(IInterface<>))
        .First();
    // get generic arguments of your interface
    var genericArguments = interfaceType.GetGenericArguments();
    // take the first argument
    var firstGenericArgument = genericArguments.First();
    // print the result (System.Int32) in your case
    Console.WriteLine(firstGenericArgument);
