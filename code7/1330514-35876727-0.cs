    var assemblies = /* get assemblies based on project type (web/desktop) */;
    foreach(var assembly in assemblies)
    {
        container.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
    }
