     private async Task<Document> HaveMethodTakeACancellationTokenParameter(
            Document document, SyntaxNode syntaxNode, CancellationToken cancellationToken)
        {
            var method = syntaxNode as MethodDeclarationSyntax;
            var cancellationTokenParameter =
               SyntaxFactory.Parameter(
                   SyntaxFactory.Identifier("cancellationToken")
               )
               .WithType(
                   SyntaxFactory.ParseTypeName(
                       typeof(CancellationToken).Name));
            
            var root = 
               (await document.GetSyntaxTreeAsync(cancellationToken))
                   .GetRoot(cancellationToken);
            var annotation = new SyntaxAnnotation();
            var newRoot = root.ReplaceNode(
                 method,
                 method.WithAdditionalAnnotations(annotation));
            #region Add Using Statements
            var systemThreadingUsingStatement =
                SyntaxFactory.UsingDirective(
                    SyntaxFactory.QualifiedName(
                        SyntaxFactory.IdentifierName("System"),
                        SyntaxFactory.IdentifierName("Threading")));
            var compilation =
                newRoot as CompilationUnitSyntax;
            if (null == compilation)
            {
                newRoot =
                    newRoot.InsertNodesBefore(
                        newRoot.ChildNodes().First(),
                        new[] {systemThreadingUsingStatement});
            }
            else if (compilation.Usings.All(u => u.Name.GetText().ToString() != typeof(CancellationToken).Namespace))
            {
                newRoot = 
                    newRoot.InsertNodesAfter(compilation.Usings.Last(), 
                    new[]{ systemThreadingUsingStatement });
            }
            #endregion
            
            method = (MethodDeclarationSyntax)newRoot.GetAnnotatedNodes(annotation).First();
            var updatedMethod = method.AddParameterListParameters(cancellationTokenParameter);
            newRoot = newRoot.ReplaceNode(method, updatedMethod.WithoutAnnotations(annotation));
            return document.WithSyntaxRoot(newRoot);
        }
