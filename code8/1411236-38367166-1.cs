    List<Type> allSubTypes = new List<Type>();
    foreach(var assem in AppDomain.CurrentDomain.GetAssemblies())
    {
        var subTypes = assem.GetTypes().Where(x => x.BaseType != null 
                             && x.BaseType.IsGenericType 
                             && x.BaseType.GetGenericTypeDefinition() == typeof(BaseClass<>));
    
        allSubTypes.AddRange(subTypes);
    }
    
    // CustomSubClass and CustomSubClass2
    foreach (var type in allSubTypes)
    {
        object instance = Activator.CreateInstance(type);
    }
