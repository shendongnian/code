       var myDeclaratyion = SyntaxFactory.LocalDeclarationStatement(
    SyntaxFactory.VariableDeclaration(
        SyntaxFactory.IdentifierName("DateTime")).
    WithVariables(
        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
            SyntaxFactory.VariableDeclarator(
                SyntaxFactory.Identifier("mydate2")).
            WithInitializer(
                SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.ObjectCreationExpression(
                        SyntaxFactory.IdentifierName("DateTime"))
                    .WithArgumentList(
                        SyntaxFactory.ArgumentList())))))).WithSemicolonToken(SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken)).NormalizeWhitespace();
