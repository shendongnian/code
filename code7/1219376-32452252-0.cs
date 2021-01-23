    SyntaxFactory
    .UsingStatement(SyntaxFactory.Block()/* the code inside the using block */)
    .WithDeclaration(SyntaxFactory
        .VariableDeclaration(SyntaxFactory.IdentifierName("var"))
        .WithVariables(SyntaxFactory.SingletonSeparatedList(SyntaxFactory
             .VariableDeclarator(SyntaxFactory.Identifier("logger"))
             .WithInitializer(SyntaxFactory.EqualsValueClause(SyntaxFactory
                 .ObjectCreationExpression(SyntaxFactory.IdentifierName(@"MethodLogger"))
                 .WithArgumentList(/* arguments for MethodLogger ctor */)))
