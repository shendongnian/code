    var memberAccessExpressionSyntax = invocationExpr.Expression as MemberAccessExpressionSyntax;
    var root = await document.GetSyntaxRootAsync(cancellationToken);
    var accessExpression = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, memberAccessExpressionSyntax.Expression, SyntaxFactory.IdentifierName("AsEnumerable"));
    var invocationExpression = SyntaxFactory.InvocationExpression(accessExpression);
    var enumerableMemberAccessExpression = memberAccessExpressionSyntax.WithExpression(invocationExpression);
    root = root.ReplaceNode(invocationExpr, invocationExpr.WithExpression(enumerableMemberAccessExpression));
