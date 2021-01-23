    public class ClassDeclarationChanger : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var methods = node.Members.OfType<MethodDeclarationSyntax>();
            if (methods.Any())
            {
                node = node.RemoveNodes(methods, SyntaxRemoveOptions.KeepExteriorTrivia);
            }
            return base.VisitClassDeclaration(node);
        }
    }
