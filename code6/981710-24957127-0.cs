    private static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
    {
        //The name would contain versioning and other information. Let's say you want to load by name.
        string dllName = e.Name.Split(new[] { ',' })[0] + ".dll";
        return Assembly.LoadFrom(Path.Combine([AssemblyDirectory], dllName));
    }
