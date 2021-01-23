    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    
        return AppDomain
                   .CurrentDomain
                   .GetAssemblies()
                   .FirstOrDefault(assembly => assembly.FullName == args.Name);
    }
