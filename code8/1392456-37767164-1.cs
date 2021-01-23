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
            var stringLiteral = (argument as ArgumentSyntax).Expression as LiteralExpressionSyntax;
            string suggestdName = this.GetSuggestedName(stringLiteral);
            var containingMember = argument.FirstAncestorOrSelf<MemberDeclarationSyntax>();
            var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
            var containingMemberSymbol = semanticModel.GetDeclaredSymbol(containingMember);
            var takenNames = containingMemberSymbol.ContainingType.MemberNames;
            string uniqueName = this.GetUniqueName(suggestdName, takenNames);
            FieldDeclarationSyntax constField = CreateConstFieldDeclaration(uniqueName, stringLiteral).WithAdditionalAnnotations(Formatter.Annotation);
            var newRoot = root.ReplaceNode(containingMember, new[] { constField, containingMember });
            newRoot = Formatter.Format(newRoot, Formatter.Annotation, document.Project.Solution.Workspace);
            return document.WithSyntaxRoot(newRoot);
        }
        private FieldDeclarationSyntax CreateConstFieldDeclaration(string uniqueName, LiteralExpressionSyntax stringLiteral)
        {
            return SyntaxFactory.FieldDeclaration(
                SyntaxFactory.List<AttributeListSyntax>(),
                SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PrivateKeyword), SyntaxFactory.Token(SyntaxKind.ConstKeyword)),
                SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.ParseTypeName("string"), 
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.VariableDeclarator(
                            SyntaxFactory.Identifier(uniqueName), 
                            argumentList: null, 
                            initializer: SyntaxFactory.EqualsValueClause(stringLiteral)))));
        }
