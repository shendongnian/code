    var typeName = "YourNamespace.ExampleObj";
    
    object obj = new
    {
        A = 5,
        B = "xx"
    };
    
    var props = TypeDescriptor.GetProperties(obj);
    Type type = Type.GetType(typeName);
    ExampleObj instance = (ExampleObj)Activator.CreateInstance(type);
    instance.A = (int)props["A"].GetValue(obj);
    instance.B = (string)props["B"].GetValue(obj);
                
    //serialize the instance now...
