        private static readonly string[] _visualStudioLineBreaks = new[] 
        { 
            "\u000D\u000A", 
            "\u000A", 
            "\u0085",
            "\u2028", 
            "\u2029" 
        };
        private string _detectLineBreakKind(SyntaxNode root)
        {
       
            foreach (var trivia in root.DescendantTokens().SelectMany(token => token.TrailingTrivia))
            {
                var triviaContent = trivia.ToFullString();
                foreach (var lineBreak in _visualStudioLineBreaks)
                {
                    if (triviaContent.Contains(lineBreak))
                        return lineBreak;
                }
            }
            return null;
        }
