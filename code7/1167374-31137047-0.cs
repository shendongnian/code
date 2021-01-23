    public override void Initialize(AnalysisContext context)
    {
        context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.InvocationExpression);
    }
    private void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
    {
        InvocationExpressionSyntax invocationExpression = context.Node as InvocationExpressionSyntax;
        IMethodSymbol methodSymbol = context.SemanticModel.GetSymbolInfo(invocationExpression).Symbol as IMethodSymbol;
        if (
            methodSymbol != null
            && methodSymbol.Name == "ReplaceNewline" 
            && methodSymbol.ContainingNamespace.Name == "MySampleFix"
            && methodSymbol.OriginalDefinition.Parameters.Length == 1)
        {
            if (invocationExpression.ArgumentList.Arguments.Count() == 1)
            {
                LiteralExpressionSyntax arg =
                    invocationExpression.ArgumentList.Arguments[0].Expression as LiteralExpressionSyntax;
                if (arg != null && arg.Token.ValueText == "|")
                {
                    Diagnostic.Create(Rule, invocationExpression.GetLocation());
                }
            }
        }
    }
