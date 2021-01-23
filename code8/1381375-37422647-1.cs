    var domain = AppDomain.CreateDomain(
        "CompiledAssemblyCheck",
        null,
        new AppDomainSetup()
        {
            LoaderOptimization = LoaderOptimization.MultiDomainHost,
            PrivateBinPath = Path.GetDirectoryName(Path.GetFullPath(otherAssembly))
        });
    try
    {
        var data = File.ReadAllBytes(otherAssembly);
        File.Delete(otherAssembly); // OK
        string myPath = new Uri(executingAssembly.GetName().CodeBase).LocalPath;
        var proxy = (AssemblyAnyLoadProxy)domain.CreateInstanceFromAndUnwrap(myPath, typeof(AssemblyAnyLoadProxy).FullName);
        proxy.LoadFrom(myPath);
        
        int outputAssemblyId = proxy.Load(data);
        
        var attrs = proxy.GetAttributes(outputAssemblyId);
    }
    finally
    {
        AppDomain.Unload(domain);
    }
        [Serializable]
        class AssemblyAnyLoadProxy : MarshalByRefObject
        {
            List<Assembly> _assemblies=new List<Assembly>();
            public int Load(byte[] raw)
            {
                Assembly asm = Assembly.ReflectionOnlyLoad(raw);
                return Add(asm);
            }
            public int LoadFrom(string assemblyFile)
            {
                Assembly asm = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
                return Add(asm);
            }
            int Add(Assembly asm)
            {
                _assemblies.Add(asm);
                return _assemblies.Count - 1;
            }
            public IList<CustomAttributeData> GetAttributes(int assembly)
            {
                return CustomAttributeData.GetCustomAttributes(_assemblies[assembly]);
            }
        }
