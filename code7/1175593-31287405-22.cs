	private IEnumerable<string> GetModuleClassDeclarations(Compilation compilation)
	{
		var trees = compilation.SyntaxTrees.ToArray();
		var models = trees.Select(compilation.GetSemanticModel(t)).ToArray();
		for (var i = 0; i < trees.Length; i++)
		{
			var tree = trees[i];
			var model = models[i];
			var types = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
			foreach (var type in types)
			{
				var symbol = model.GetDeclaredSymbol(type) as ITypeSymbol;
				if (symbol != null && Filter(symbol))
				{
					yield return GetFullMetadataName(symbol);
				}
			}
		}
	}
