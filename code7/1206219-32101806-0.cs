                context.RegisterCodeFix(CodeAction.Create("Convert to 'return' statement", async token =>
            {
                var editor = await DocumentEditor.CreateAsync(document, cancellationToken);
                var statementCondition = (node as IfStatementSyntax)?.Condition;
                var newReturn = SyntaxFactory.ReturnStatement(SyntaxFactory.Token(SyntaxKind.ReturnKeyword),
                    statementCondition, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                editor.ReplaceNode(node as IfStatementSyntax, newReturn
                    .WithLeadingTrivia(node.GetLeadingTrivia())
                    .WithAdditionalAnnotations(Formatter.Annotation));
                var block = node.Parent as BlockSyntax;
                if (block == null)
                    return null;
                var returnStatementAfterIfStatementIndex = block.Statements.IndexOf(node as IfStatementSyntax) + 1;
                var returnStatementToBeEliminated = block.Statements.ElementAt(returnStatementAfterIfStatementIndex) as ReturnStatementSyntax;
                editor.RemoveNode(returnStatementToBeEliminated);
                var newDocument = editor.GetChangedDocument();
                return newDocument;
            }, string.Empty), diagnostic);
