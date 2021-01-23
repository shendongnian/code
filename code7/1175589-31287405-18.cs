	private IEnumerable<string> GetAssemblyModules(PortableExecutableReference reference)
	{
		var metadata = GetMetadataMethodInfo.Invoke(reference, nul) as AssemblyMetadata;
		if (metadata != null)
		{
			var assemblySymbol = ((IEnumerable<IAssemblySymbol>)CachedSymbolsFieldInfo.GetValue(metadata)).First();
			// Only consider our assemblies? Sample*?
			if (assemblySymbol.Name.StartsWith("Sample"))
			{
				var types = GetTypeSymbols(assemblySymbol.GlobalNamespace).Where(t => Filter(t));
				return types.Select(t => GetFullMetadataName(t)).ToArray();
			}
		}
		return Enumerable.Empty<string>();
	}
