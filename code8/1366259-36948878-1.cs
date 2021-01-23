    private async Task<Document> HaveMethodTakeACancellationTokenParameter(
            Document document, SyntaxNode syntaxNode, CancellationToken cancellationToken)
        {
            var method = syntaxNode as MethodDeclarationSyntax;
            var updatedMethod = method.AddParameterListParameters(
                SyntaxFactory.Parameter(
                    SyntaxFactory.Identifier("cancellationToken"))
                    .WithType(SyntaxFactory.ParseTypeName(typeof (CancellationToken).FullName)));
            var syntaxTree = await document.GetSyntaxTreeAsync(cancellationToken);
            var updatedSyntaxTree = 
                syntaxTree.GetRoot().ReplaceNode(method, updatedMethod);
            return document.WithSyntaxRoot(updatedSyntaxTree);
        }
