    context.RegisterSyntaxNodeAction(
        c =>
        {
            var invocation = (InvocationExpressionSyntax)c.Node;
            var symbol = c.SemanticModel.GetSymbolInfo(invocation.Expression).Symbol as IMethodSymbol;
            if (!IsMyMethod(symbol))
            {
                return;
            }
            if (invocation.ArgumentList != null &&
                invocation.ArgumentList.Arguments
                    .Select(a => a.Expression)
                    .OfType<InvocationExpressionSyntax>()
                    .Any(i => i.Expression.ToString() == "nameof"))
            {
                c.ReportDiagnostic(...);
            }
        },
        SyntaxKind.InvocationExpression);
