    Assembly assembly = Assembly.LoadFile("YourAssembly.dll");
    Type type = assembly.GetType("NameSpace.AAB"); 
    var aabInstance = Activator.CreateInstance(type, null);
    MethodInfo methodInfo = type.GetMethod("CalAAB");
    var result = methodInfo.Invoke(classInstance, param1, param2);
