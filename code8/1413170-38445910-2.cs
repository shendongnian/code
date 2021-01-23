        public class MyRewriter : CSharpSyntaxRewriter
    {
    public MyRewriter(): base(true)
    {
    }
    public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
    {
        if(trivia.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia)
        {
            string xml = trivia.ToFullString();
            var TestEntryArgName = "__tst";
            char[] delim = { ' ', '\n', '\t', '\r' };
            var ar = xml.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            if (ar.Length != 3 || ar[1] != "add")
            {
                return base.VisitTrivia(trivia);
            }
            var lineToAdd = TestEntryArgName + ".AddElement(" + ar[2] + ")";
            var expression = SyntaxFactory.SyntaxTrivia(SyntaxKind.SingleLineCommentTrivia, lineToAdd);
            return expression;
        }
        return base.VisitTrivia(trivia);
        }
    }
