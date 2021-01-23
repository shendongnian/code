    public override SyntaxNode VisitEmptyStatement(EmptyStatementSyntax node)
    {
        return node.WithSemicolonToken(
            SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken)
                .WithLeadingTrivia(node.SemicolonToken.LeadingTrivia)
                .WithTrailingTrivia(node.SemicolonToken.TrailingTrivia));
    }
