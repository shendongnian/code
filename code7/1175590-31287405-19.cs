	private IEnumerable<ITypeSymbol> GetTypeSymbols(INamespaceSymbol ns)
	{
		foreach (var typeSymbols in ns.GetTypeMembers().Where(t => !t.Name.StartsWith("<")))
		{
			yield return typeSymbol;
		}
		foreach (var namespaceSymbol in ns.GetNamespaceMembers())
		{
			foreach (var typeSymbol in GetTypeSymbols(ns))
			{
				yield return typeSymbol;
			}
		}
	}
