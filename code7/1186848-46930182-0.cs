    AppDomain dom = AppDomain.CreateDomain("some");     
    AssemblyName assemblyName = new AssemblyName();
    assemblyName.CodeBase = pathToAssembly;
    Assembly assembly = dom.Load(assemblyName);
    //Do something with the loaded 'assembly'
    AppDomain.Unload(dom);
