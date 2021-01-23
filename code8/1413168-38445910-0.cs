    public class MyRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode     VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
        string xml = node.GetText().ToString();
        var TestEntryArgName = "__tst";
        char[] delim = { ' ', '\n', '\t', '\r' };
        var ar = xml.Split(delim, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length != 3 || ar[1] != "add")
        {
            return base.VisitDocumentationCommentTrivia(node);
        }
        var lineToAdd = TestEntryArgName + ".AddElement(" + ar[2] + ")";
        var expression = SyntaxFactory.ExpressionStatement(SyntaxFactory.ParseExpression(lineToAdd));
        return expression;
        }
    }
