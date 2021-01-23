        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;
            var argument = root.FindNode(diagnosticSpan);
            if (!IsBadStringLiteralArgument(argument))
            {
                return;
            }
            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(
                    title: title,
                    createChangedDocument: (ct) => InlineConstField(context.Document, root, argument, ct),
                    equivalenceKey: title),
                diagnostic);
        }
        private async Task<Document> InlineConstField(Document document, SyntaxNode root, SyntaxNode argument, CancellationToken cancellationToken)
        {
            string suggestdName = GetSuggestedName((argument as ArgumentSyntax).Expression as LiteralExpressionSyntax);
            var containingMember = argument.FirstAncestorOrSelf<MemberDeclarationSyntax>();
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
            var containingMemberSymbol = semanticModel.GetDeclaredSymbol(containingMember);
            var takenNames = containingMemberSymbol.ContainingType.MemberNames;
            string uniqueName = this.GetUniqueName(suggestdName, takenNames);
            FieldDeclarationSyntax constField = CreateConstFieldDeclaration(uniqueName).WithAdditionalAnnotations(Formatter.Annotation);
            var newRoot = root.ReplaceNode(containingMember, new[] { constField, containingMember });
            newRoot = Formatter.Format(newRoot, Formatter.Annotation, document.Project.Solution.Workspace);
            return document.WithSyntaxRoot(newRoot);
        }
