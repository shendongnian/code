    public static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += _HandleAssemblyResolve;
    }
    private Assembly _HandleAssemblyResolve(object sender, ResolveEventArgs args)
    {
        var firstOrDefault = args.Name.Split(',').FirstOrDefault();
        return Assembly.Load(firstOrDefault);
    }
