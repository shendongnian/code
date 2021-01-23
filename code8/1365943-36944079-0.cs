    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => ImmutableArray.Create(BadSqlRule, MissingOptionsFileRule);
    public override void Initialize(AnalysisContext context)
    {
        context.RegisterCompilationStartAction(AnalyzeCompilationStart);
        context.RegisterCompilationAction(AnalyzeCompilation);
        context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.InvocationExpression);
    }
    private Config config = null;
    private void AnalyzeCompilationStart(CompilationStartAnalysisContext context)
    {
        var configFile = context.Options.AdditionalFiles
            .SingleOrDefault(f => Path.GetFileName(f.Path) == "myconfig.json");
        config = configFile == null
            ? null
            : new Config(configFile.GetText(context.CancellationToken).ToString());
    }
    private void AnalyzeCompilation(CompilationAnalysisContext context)
    {
        if (config == null)
            context.ReportDiagnostic(Diagnostic.Create(MissingOptionsFileRule, Location.None));
    }
    private void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
        if (config == null)
            return;
        var node = (InvocationExpressionSyntax) context.Node;
        var symbol = (IMethodSymbol) context.SemanticModel.GetSymbolInfo(
            node, context.CancellationToken).Symbol;
        // TODO: properly check it's one of the methods we analyze
        if (symbol.ToDisplayString().Contains(".Execute(string"))
        {
            var arguments = node.ArgumentList.Arguments;
            if (arguments.Count == 0)
                return;
            var firstArgument = arguments.First().Expression;
            if (!firstArgument.IsKind(SyntaxKind.StringLiteralExpression))
                return;
            var sqlString = (string)((LiteralExpressionSyntax) firstArgument).Token.Value;
            if (Verify(config, sqlString))
                return;
            context.ReportDiagnostic(
                Diagnostic.Create(BadSqlRule, firstArgument.GetLocation(), sqlString));
        }
    }
