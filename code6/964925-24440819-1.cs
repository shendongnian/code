    public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        if (node.CSharpKind() == SyntaxKind.GreaterThanExpression)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, node.Left, node.Right);
        }
        return node;
    }
