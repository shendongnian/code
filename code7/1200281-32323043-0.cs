    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name == "TestLibaryA...")
        {
            return Assembly.LoadFrom("TestLibaryA's Path");
        }
        return null;
    }
