    private static IEnumerable<string> FindUsedUsings(SemanticModel model, SyntaxNode node)
    {
        foreach (var identifier in node.DescendantNodesAndSelf())
        {
            var typeInfo = model.GetTypeInfo(identifier);
            if (typeInfo.Type != null)
            {
                yield return typeInfo.Type.ContainingNamespace.ToDisplayString();
            }
        }
    }
