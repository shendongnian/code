        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            node = node.WithBaseList(
                SyntaxFactory.BaseList()
                    .WithTypes(
                       SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                           SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseName("Form"))
                               .WithLeadingTrivia(SyntaxFactory.Space) 
                               .WithTrailingTrivia(SyntaxFactory.LineFeed)
                        )
                    )
                );
            node =
                node.WithIdentifier(
                    node.Identifier.WithTrailingTrivia
                        (SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, " ")));
            return base.VisitClassDeclaration(node);
        }
