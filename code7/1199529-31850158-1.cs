    var anotherAssemblyTypes = Assembly.LoadAssembly("AnotherAssemblyFile").GetTypes();
    // get interface type
    Type outerInterface = anotherAssemblyTypes
                            .Single(t => t.Name == "ISample" && t.IsInterface);
    // find class which implements it
    Type outerClass = anotherAssemblyTypes
                            .Single(t => !t.IsInterface && outerInterface.IsAssignableFrom(t));
    // instantiate class
    dynamic obj = Activator.CreateInstance(outerClass);
    string result = obj.SampleMethod("Bob");
