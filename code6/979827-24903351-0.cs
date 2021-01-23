    Assembly assm = Assembly.GetExecutingAssembly();
    //Assembly assm = Assembly.GetCallingAssembly();
    //Assembly assm   = Assembly.GetEntryAssembly();
    //Assembly assm = Assembly.Load("//");
    // it depends in which assmebly you are expecting the type to be declared
    
    // Single protects us - if more than one "Example" type will be found (with different namespaces)
    // throws exception (we don't know which type to use)
    // when null - type not found
    Type myType = assm.GetTypes().SingleOrDefault(type => type.Name.Equals("Example"));
