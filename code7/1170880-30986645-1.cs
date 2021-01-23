    static void TransformParameterOrder(string sourceCode)
    {
        var tree = CSharpSyntaxTree.ParseText(sourceCode);
        var root = (CompilationUnitSyntax)tree.GetRoot();
        var @namespace = (NamespaceDeclarationSyntax)
            root.ChildNodes().First(n => n.Kind() == SyntaxKind.NamespaceDeclaration);
        var @class = (ClassDeclarationSyntax)
            @namespace.ChildNodes().First(n => n.Kind() == SyntaxKind.ClassDeclaration);
        var constructor = (ConstructorDeclarationSyntax)
           @class.ChildNodes().First(n => n.Kind() == SyntaxKind.ConstructorDeclaration);
        var child = constructor.ParameterList.ChildNodes().Count();
        var parameters = constructor.ParameterList
            .ChildNodes()
            .Cast<ParameterSyntax>()
            .OrderBy(node => ((IdentifierNameSyntax)node.Type).Identifier.ToString())
            .Select(node => SyntaxFactory.Parameter(
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.TokenList(),
                SyntaxFactory.ParseTypeName(((IdentifierNameSyntax)node.Type).Identifier.Text),
                SyntaxFactory.Identifier(node.Identifier.Text),
                null))
            .Take(2);
        var updatedParameterList = SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters));
        var newNode = ((SyntaxNode)constructor).ReplaceNode(constructor.ParameterList, updatedParameterList);
        //Alternatively you can assign root = root.ReplaceNode...
        var newRoot = root.ReplaceNode(constructor.ParameterList, updatedParameterList);
        Console.WriteLine(root.GetText().ToString());
        Console.WriteLine(newRoot.GetText().ToString());
    }
