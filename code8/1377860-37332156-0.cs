    var loadableAssemblies = new List<Assembly>();
    
    var deps = DependencyContext.Default;            
    foreach (var compilationLibrary in deps.CompileLibraries)
    {
    	if (compilationLibrary.Name.Contains(projectNamespace))
    	{
    		var assembly = Assembly.Load(new AssemblyName(compilationLibrary.Name));
    		loadableAssemblies.Add(assembly);
    	}
    }
