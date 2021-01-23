	var variableDeclaration = (VariableDeclarationSyntax)context.Node;
	var type = context.SemanticModel.GetTypeInfo(variableDeclaration.Type).Type;
	if ((type != null) && !(type is IErrorTypeSymbol)) // This will happen if the type lookup fails
	{
		var ns = type.ContainingNamespace;
	}
