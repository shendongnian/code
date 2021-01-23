    public static class SyntaxNodeExtensions
    {
        public static bool IsEquivalentToWithCommentsPreserved(this SyntaxNode syntaxNode, SyntaxNode otherNode)
        {
            return NonCommentTriviaRemover.Default.Visit(syntaxNode)
                   .IsEquivalentTo(NonCommentTriviaRemover.Default.Visit(otherNode));
        }
        
        private class NonCommentTriviaRemover : CSharpSyntaxRewriter
        {
            public static readonly NonCommentTriviaRemover Default = new NonCommentTriviaRemover();
        
            private static readonly SyntaxTrivia EmptyTrivia = default(SyntaxTrivia);
            
            public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
            {
                if (trivia.IsKind(SyntaxKind.SingleLineCommentTrivia) || trivia.IsKind(SyntaxKind.MultiLineCommentTrivia))
                    return trivia; // Preserve comments by returning the original comment trivia.
                    
                return EmptyTrivia; // Remove all other trivias.
            }
        }
    }
