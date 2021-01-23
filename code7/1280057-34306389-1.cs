    var asm1Container = new lazy<Container>(Asm1Bootstrapper.Bootstrap);
    var asm2Container = new lazy<Container>(Asm2Bootstrapper.Bootstrap);
    var asm3Container = new lazy<Container>(Asm3Bootstrapper.Bootstrap);
    mainContainer.ResolveUnregisteredType += (s, e) =>
    {
        var asmContainer = GetAssemblyContainer(e.UnregisteredServiceType.Assembly);
        e.Register(() => asmContainer.GetInstance(e.UnregisteredServiceType));
    }
    private Container GetAssemblyContainer(Assembly assembly) {
        string assemblyName = assembly.FullName;
        if (assemblyName.Contains("Assembly1"))
            asm1Container.Value;
        if (assemblyName.Contains("Assembly2"))
            asm2Container.Value;
        if (assemblyName.Contains("Assembly3"))
            asm3Container.Value;
        // etc
    }
