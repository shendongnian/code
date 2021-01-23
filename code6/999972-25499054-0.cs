    // gets the Type
    Type type = list[0].GetType(); 
    
    // gets public, parameterless constructor
    ConstructorInfo ci = type.GetConstructor(new Type[0]);
    
    // instantiates the object
    object obj = ci.Invoke(new object[0]);
