    private async Task<Solution> AddCustomAttribute(Document document, MethodDeclarationSyntax methodDeclaration, CancellationToken cancellationToken)
    {
    	var root = await document.GetSyntaxRootAsync(cancellationToken);
    	var attributes = methodDeclaration.AttributeLists.Add(
    		SyntaxFactory.AttributeList(SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
    			SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("CustomAttribute"))
    			//  .WithArgumentList(...)
    		)).NormalizeWhitespace());
    	
        return document.WithSyntaxRoot(
            root.ReplaceNode(
                methodDeclaration,
                methodDeclaration.WithAttributeLists(attributes)
            )).Project.Solution;
    }
