    MethodDeclarationSyntax newMethod = SyntaxFactory.MethodDeclaration(
        SyntaxFactory.List<AttributeListSyntax>(),
        SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PrivateKeyword)),
        SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
        null,
        SyntaxFactory.Identifier("simpleButton1_Click"),
        null,
        SyntaxFactory.ParameterList(parametersList),
        SyntaxFactory.List<TypeParameterConstraintClauseSyntax>(),
        SyntaxFactory.Block(),
        null
      )
    newMethod = newMethod.NormalizeWhitespace();
