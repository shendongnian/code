    public class SampleChanger : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            // Generates a node containing only parenthesis 
            // with no identifier, no return type and no parameters
            var newNode = SyntaxFactory.MethodDeclaration(SyntaxFactory.IdentifierName(""), "");
            // Removes the parenthesis from the Parameter List 
            // and replaces them with MissingTokens
            newNode = newNode.ReplaceNode(newNode.ParameterList,
                newNode.ParameterList.WithOpenParenToken(
                    SyntaxFactory.MissingToken(SyntaxKind.OpenParenToken)).
                WithCloseParenToken(SyntaxFactory.MissingToken(SyntaxKind.CloseParenToken)));
            // Returns the new method containing no content 
            // but the Leading and Trailing trivia of the previous node
            return newNode.WithLeadingTrivia(node.GetLeadingTrivia()).
                WithTrailingTrivia(node.GetTrailingTrivia());
        }
    }
