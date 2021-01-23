    static MyTestDllClass() // static constructor
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);
    }
    static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
    {
        string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
        if (File.Exists(assemblyPath) == false) return null;
        Assembly assembly = Assembly.LoadFrom(assemblyPath);
        return assembly;
    }
