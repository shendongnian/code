    string customizedAssemblyName = "CustomerAServices"; // Get from config
    container.Register(Classes
        .FromAssemblyNamed(customizedAssemblyName)
        .InNamespace(customizedAssemblyName + ".Services")
        .WithServiceAllInterfaces());
    
    container.Register(Classes
       .FromAssemblyNamed("CoreServices")
       .InNamespace("CoreServices.Services")
       .WithServiceAllInterfaces());
