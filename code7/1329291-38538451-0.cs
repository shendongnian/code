    var assembly = Assembly.LoadFile(fullpathofexecutable);
    BindingFlags eFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
    
    Type classInstance = GetClass("Class196", assembly.GetTypes());
    
    MethodInfo myMethod = classInstance.GetMethod("methodThatIWantToExecute", eFlags);
    
    object[] arguments = {1,2,3 };
    string result = (string)myMethod.Invoke(null, arguments);
