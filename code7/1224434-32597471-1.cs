    public override void Initialize(AnalysisContext context)
    {
        context.RegisterSyntaxTreeAction((syntaxTreeContext) =>
        {
            var filePath = syntaxTreeContext.Tree.FilePath;
            if (filePath == null)
                return;
            var namespaceNodes = syntaxTreeContext.Tree.GetRoot().ChildNodes().OfType<NamespaceDeclarationSyntax>();
            var parentDirectory = System.IO.Path.GetDirectoryName(filePath);
            // This will only work on windows and is not very robust.
            var parentDirectoryWithDots = parentDirectory.Replace("\\", ".").ToLower();
            foreach (var ns in namespaceNodes)
            {
                if (!parentDirectoryWithDots.EndsWith(ns.Name.ToFullString().ToLower().Trim()))
                {
                    syntaxTreeContext.ReportDiagnostic(Diagnostic.Create(Rule, ns.Name.GetLocation(), parentDirectoryWithDots));
                }
            }
        });
    }
