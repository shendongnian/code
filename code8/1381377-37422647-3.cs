    var domain = AppDomain.CreateDomain(
        "CompiledAssemblyCheck",
        null,
        new AppDomainSetup()
        {
            LoaderOptimization = LoaderOptimization.MultiDomainHost,
            PrivateBinPath = Path.GetDirectoryName(Path.GetFullPath(otherAssembly)),
            ShadowCopyFiles = "true"
        });
    try
    {
        var data = File.ReadAllBytes(otherAssembly);
        string myPath = new Uri(executingAssembly.GetName().CodeBase).LocalPath;
        var proxy = (AssemblyAnyLoadProxy)domain.CreateInstanceFromAndUnwrap(myPath, typeof(AssemblyAnyLoadProxy).FullName);
        proxy.LoadFrom(myPath);
        
        int outputAssemblyId = proxy.Load(data);
        
        bool same = proxy.CompareAttribute(outputAssemblyId, typeof(MyAssemblyAttribute).FullName, expectedArgs);
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
            public bool CompareAttribute(int assembly, string fullName, object[] args)
            {
                var attrs = CustomAttributeData.GetCustomAttributes(_assemblies[assembly]);
                CustomAttributeData attr = attrs.FirstOrDefault(x => x.Constructor.DeclaringType.FullName == fullName);
                return attr?.ConstructorArguments.Select(x => x.Value).SequenceEqual(args) ?? false;
            }
        }
