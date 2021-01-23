    context.RegisterSyntaxNodeAction((analysisContext) =>
    {
        var invocations =
            analysisContext.Node.DescendantNodes().OfType<MemberAccessExpressionSyntax>();
        var hasValueCalls = new HashSet<string>();
        foreach (var invocation in invocations)
        {
            var e = invocation.Expression as IdentifierNameSyntax;
            if (e == null)
                continue;
            string variableName = e.Identifier.Text;
            if (invocation.Name.ToString() == "HasValue")
            {
                hasValueCalls.Add(variableName);
            }
            if (invocation.Name.ToString() == "GetValue")
            {
                if (!hasValueCalls.Contains(variableName))
                {
                    analysisContext.ReportDiagnostic(Diagnostic.Create(Rule, e.GetLocation()));
                }
            }
        }
    }, SyntaxKind.MethodDeclaration);
