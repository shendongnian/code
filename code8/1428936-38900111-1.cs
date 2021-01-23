	private static IEnumerable<string> FindUsedUsings(SemanticModel model, SyntaxNode node)
	{
		var resultList = new List<string>();
		foreach (var identifier in node.DescendantNodesAndSelf())
		{
			var typeInfo = model.GetTypeInfo(identifier);
			if (typeInfo.Type != null)
			{
				resultList.Add(typeInfo.Type.ContainingNamespace.ToDisplayString());
			}
		}
		return resultList.Distinct().ToList();
	}
