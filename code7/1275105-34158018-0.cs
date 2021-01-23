	var result = document.Project.Solution;
	var m = start.Parent.AncestorsAndSelf().OfType<MethodDeclarationSyntax>().First(); // the method to add
	var t = start.Parent.AncestorsAndSelf().OfType<ClassDeclarationSyntax>().First(); // the class type
	var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
	var typeSymbol = semanticModel.GetDeclaredSymbol(t, cancellationToken);
	var i = typeSymbol.Interfaces; // the interfaces in the semantic model. Includes declared interfaces on all partial classes.
	// does the type implement the interface?
	var implements = false;
	foreach (var b in i)
	{
		if (b.Name == "IInterfaceName")
		{
			implements = true;
			break;
		}
	}
	if (!implements)
	{
		var newClass = t.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("IInterfaceName")));
		// get root for current document and replace statement with new version
		var root = await document.GetSyntaxRootAsync(cancellationToken);
		var newRoot = root.ReplaceNode(t, newClass);
		// return new solution
		result = document.WithSyntaxRoot(newRoot).Project.Solution;
	}
	
	return result;
