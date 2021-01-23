    var constField = SyntaxFactory.FieldDeclaration(
        SyntaxFactory.VariableDeclaration(
            SyntaxFactory.PredefinedType(
                SyntaxFactory.Token(SyntaxKind.StringKeyword)))
        .WithVariables(
            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                SyntaxFactory.VariableDeclarator(
                    SyntaxFactory.Identifier("MyString"))
                .WithInitializer(
                    SyntaxFactory.EqualsValueClause(
                        SyntaxFactory.LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal("This is my string")))))))
    .WithModifiers(
        SyntaxFactory.TokenList(
            new []{
                SyntaxFactory.Token(SyntaxKind.PrivateKeyword),
                SyntaxFactory.Token(SyntaxKind.ConstKeyword)}))))))
