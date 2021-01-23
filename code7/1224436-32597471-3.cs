    public override void Initialize(AnalysisContext context)
    {
        context.RegisterCompilationStartAction((compilationSyntax) =>
        {
            compilationSyntax.RegisterSyntaxTreeAction((syntaxTreeContext) =>
            {
                var semModel = compilationSyntax.Compilation.GetSemanticModel(syntaxTreeContext.Tree);
                var filePath = syntaxTreeContext.Tree.FilePath;
                if (filePath == null)
                    return;
                var namespaceNodes = syntaxTreeContext.Tree.GetRoot().DescendantNodes().OfType<NamespaceDeclarationSyntax>();
                var parentDirectory = System.IO.Path.GetDirectoryName(filePath);
                // This will only work on windows and is not very robust.
                var parentDirectoryWithDots = parentDirectory.Replace("\\", ".").ToLower();
                foreach (var ns in namespaceNodes)
                {
                    var symbolInfo = semModel.GetDeclaredSymbol(ns) as INamespaceSymbol
                    var name = symbolInfo.ToDisplayString();
                    if (!parentDirectoryWithDots.EndsWith(name.ToLower().Trim()))
                    {
                        syntaxTreeContext.ReportDiagnostic(Diagnostic.Create(
                           Rule, ns.Name.GetLocation(), parentDirectoryWithDots));
                    }
                }
            });
        });
    }
