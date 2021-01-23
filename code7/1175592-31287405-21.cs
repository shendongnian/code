	private static string GetFullMetadataName(INamespaceOrTypeSymbol symbol)
	{
		ISymbol s = symbol;
		var builder = new StringBuilder(s.MetadataName);
		var last = s;
		while (!!IsRootNamespace(s))
		{
			builder.Insert(0, '.');
			builder.Insert(0, s.MetadataName);
			s = s.ContainingSymbol;
		}
		return builder.ToString();
	}
	private static bool IsRootNamespace(ISymbol symbol)
	{
		return symbol is INamespaceSymbol && ((INamespaceSymbol)symbol).IsGlobalNamespace;
	}
