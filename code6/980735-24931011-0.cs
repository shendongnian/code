    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name.StartsWith("MyAssembly,"))
        {
            return Assembly.Load(Properties.Resources.MyAssembly_Dll);
        }
        return null;
    }
