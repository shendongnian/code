    ...
    SyntaxNode root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
	var interfaceDeclaration = root.DescendantNodes(node => node.IsKind(SyntaxKind.InterfaceDeclaration)).FirstOrDefault() as InterfaceDeclarationSyntax;
    if (interfaceDeclaration == null) return;
    var methodToInsert= GetMethodDeclarationSyntax(returnTypeName: "GetSomeDataResponse ", 
	          methodName: "GetSomeData", 
	          parameterTypes: new[] { "GetSomeDataRequest" }, 
	          paramterNames: new[] { "request" });
    var newInterfaceDeclaration = interfaceDeclaration.AddMembers(methodToInsert);
	
    var newRoot = root.ReplaceNode(interfaceDeclaration, newInterfaceDeclaration);
    
    // this will format all nodes that have Formatter.Annotation
    newRoot = Formatter.Format(newRoot, Formatter.Annotation, workspace);
    workspace.TryApplyChanges(document.WithSyntaxRoot(newRoot).Project.Solution);
    ...
    public MethodDeclarationSyntax GetMethodDeclarationSyntax(string returnTypeName, string methodName, string[] parameterTypes, string[] paramterNames)
    {
	    var parameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(GetParametersList(parameterTypes, paramterNames)));
	    return SyntaxFactory.MethodDeclaration(attributeLists: SyntaxFactory.List<AttributeListSyntax>(), 
	                  modifiers: SyntaxFactory.TokenList(), 
	                  returnType: SyntaxFactory.ParseTypeName(returnTypeName), 
	                  explicitInterfaceSpecifier: null, 
	                  identifier: SyntaxFactory.Identifier(methodName), 
	                  typeParameterList: null, 
	                  parameterList: parameterList, 
	                  constraintClauses: SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(), 
	                  body: null, 
	                  semicolonToken: SyntaxFactory.Token(SyntaxKind.SemicolonToken))
              // Annotate that this node should be formatted
              .WithAdditionalAnnotations(Formatter.Annotation);
    }
    private IEnumerable<ParameterSyntax> GetParametersList(string[] parameterTypes, string[] paramterNames)
    {
        for (int i = 0; i < parameterTypes.Length; i++)
        {
			yield return SyntaxFactory.Parameter(attributeLists: SyntaxFactory.List<AttributeListSyntax>(),
													 modifiers: SyntaxFactory.TokenList(),
													 type: SyntaxFactory.ParseTypeName(parameterTypes[i]),
													 identifier: SyntaxFactory.Identifier(paramterNames[i]),
													 @default: null);
		}
	}
