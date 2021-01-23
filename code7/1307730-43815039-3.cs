    public static class SyntaxNodeExtensions
    {
        public static bool IsEquivalentToWithCommentsPreserved(this SyntaxNode syntaxNode, SyntaxNode otherNode)
        {
            var triviaRemover = new NonCommentTriviaRemover();
            return triviaRemover.Visit(syntaxNode)
                   .IsEquivalentTo(triviaRemover.Visit(otherNode));
        }
        private class NonCommentTriviaRemover : CSharpSyntaxRewriter
        {
            private static readonly SyntaxTrivia EmptyTrivia = default(SyntaxTrivia);
            public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
            {
                return trivia.IsKind(SyntaxKind.SingleLineCommentTrivia) ||
                       trivia.IsKind(SyntaxKind.MultiLineCommentTrivia)
                    ? trivia // Preserve comments by returning the original comment trivia.
                    : EmptyTrivia; // Remove all other trivias.
            }
        }
    }
