    private static void AnalyzeSymbol(SymbolAnalysisContext context)
    {
        var compilation = context.Compilation;
        var syntax = context.Symbol.DeclaringSyntaxReferences.First(); //Careful, partial methods might burn you
        var model = compilation.GetSemanticModel(syntax.SyntaxTree);
        //Use your model however you please!
    }
