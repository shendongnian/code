    var typeClass = typeof(T); // Or maybe Type.GetType("myNamespace.myClass")
    var listInstance = (System.Collections.IList)typeof(List<>)
                                    .MakeGenericType(typeClass)
                                    .GetConstructor(Type.EmptyTypes)
                                    .Invoke(null);
    // Add Some instance from T
    var objectInstance = Activator.CreateInstance(typeClass); // Create a Instance
    listInstance.Add(objectInstance);
