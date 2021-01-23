    public async override Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var diagnostic = context.Diagnostics.First();
        context.RegisterCodeFix(CodeAction.Create("Remove 'params' modifier", async token =>
        {
            
            var document = context.Document;
            var root = await document.GetSyntaxRootAsync(token);
            var fullParameterNode = root.FindNode(diagnostic.Location.SourceSpan, false) as ParameterSyntax;
            // Keep all modifiers except the params
            var newModifiers = fullParameterNode.Modifiers.Where(m => !m.IsKind(SyntaxKind.ParamsKeyword));
            var syntaxModifiers = SyntaxTokenList.Create(new SyntaxToken());
            syntaxModifiers.AddRange(newModifiers);
            var updatedParameterNode = fullParameterNode.WithModifiers(syntaxModifiers);
            var newDoc = document.WithSyntaxRoot(root.ReplaceNode(fullParameterNode, updatedParameterNode));
            return newDoc;
        }, "KEY"), diagnostic);
    }
