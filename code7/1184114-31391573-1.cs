    string[] assembliesToProcess = ...;
    // create the temporary appdomain
    var appDomain = AppDomain.CreateDomain(...);
    try
    {
        // create a MyClass instance within the temporary appdomain
        var o = (MyClass) appDomain.CreateInstanceFromAndUnwrap(
            typeof(MyClass).Assembly.Location,
            typeof(MyClass).FullName);
        // call into the temporary appdomain to process the assemblies
        o.ProcessAssemblies(assembliesToProcess);
    }
    finally
    {
        // unload the temporary appdomain
        AppDomain.Unload(appDomain);
    }
