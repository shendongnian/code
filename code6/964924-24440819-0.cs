    public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        if (node.CSharpKind() == SyntaxKind.GreaterThanExpression)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, binaryExpression.Left, binaryExpression.Right);
        }
        return node;
    }
