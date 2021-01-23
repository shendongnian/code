    public override void Initialize(AnalysisContext context)
    {
        context.RegisterSyntaxNodeAction(AnalyzeIt, SyntaxKind.MethodDeclaration);
    }
    private static void AnalyzeIt(SyntaxNodeAnalysisContext context)
    {
        var method = context.Node as MethodDeclarationSyntax;
        var dataFlow = context.SemanticModel.AnalyzeDataFlow(method.Body);
        var variablesDeclared = dataFlow.VariablesDeclared;
        var variablesRead = dataFlow.ReadInside.Union(dataFlow.ReadOutside);
        var unused = variablesDeclared.Except(variablesRead);
        if (unused.Any())
        {
            foreach (var unusedVar in unused)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rule, unusedVar.Locations.First()));
            }
        }
    }
