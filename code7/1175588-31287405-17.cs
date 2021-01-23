	private IEnumerable<string> GetAvailableModules(Compilation compilation)
	{
		var list = new List<string>();
		string[] modules = null;
		
		// Get the available references.
		var refs = compilation.References.ToList();
		// Get the assembly references.
		var assemblies = refs.OfType<PortableExecutableReference>().ToList();
		foreach (var assemblyRef in assemblies)
		{
			if (!_cache.TryGetValue(assemblyRef, out modules))
			{
				modules = GetAssemblyModules(assemblyRef);
				_cache.AddOrUpdate(assemblyRef, modules, (k, v) => modules);
				list.AddRange(modules);
			}
			else
			{
				// We've already included this assembly.
			}
		}
		// Get the compilation references
		var compilations = refs.OfType<CompilationReference>().ToList();
		foreach (var compliationRef in compilations)
		{
			if (!_cache.TryGetValue(compilationRef, out modules))
			{
				modules = GetAvailableModules(compilationRef.Compilation).ToArray();
				_cache.AddOrUpdate(compilationRef, modules, (k, v) => modules);
				list.AddRange(modules);
			}
			else
			{
				// We've already included this compilation.
			}
		}
		// Finally, deal with modules in the current compilation.
		list.AddRange(GetModuleClassDeclarations(compilation));
		return list;
	}
