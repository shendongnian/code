    var statements = new SyntaxList<StatementSyntax>();
    //Tried bundling newNode and invocation together
    statements.Add(SyntaxFactory.ExpressionStatement(newNode));
    statements.Add(SyntaxFactory.ExpressionStatement(invocation));
    var wrapper = SyntaxFactory.Block(statements);
    //Now we can remove the { and } braces
    wrapper = wrapper.WithOpenBraceToken(SyntaxFactory.MissingToken(SyntaxKind.OpenBraceToken))
    .WithCloseBraceToken(SyntaxFactory.MissingToken(SyntaxKind.CloseBraceToken));
