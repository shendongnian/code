    var console = SyntaxFactory.IdentifierName("Console");
    var writeline = SyntaxFactory.IdentifierName("WriteLine");
    var memberaccess = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, console, writeline);
    var argument = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal("A")));
    var argumentList = SyntaxFactory.SeparatedList(new[] { argument });
    var writeLineCall =
        SyntaxFactory.ExpressionStatement(
        SyntaxFactory.InvocationExpression(memberaccess,
        SyntaxFactory.ArgumentList(argumentList)));
