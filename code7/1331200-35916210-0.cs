    public class SolutionAttributeUpdater
    {
        public static async Task<Solution> UpdateAttributes(Solution solution)
        {
            foreach (var project in solution.Projects)
            {
                foreach (var document in project.Documents)
                {
                    var syntaxTree = await document.GetSyntaxTreeAsync();
                    var root = syntaxTree.GetRoot();
                    var descentants = root.DescendantNodes().Where(curr => curr is AttributeListSyntax).ToList();
                    if (descentants.Any())
                    {
                        var attributeList = SyntaxFactory.AttributeList(
                            SyntaxFactory.SingletonSeparatedList(
                                SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("Cookies"), SyntaxFactory.AttributeArgumentList(SyntaxFactory.SeparatedList(new[] { SyntaxFactory.AttributeArgument(
                                        SyntaxFactory.LiteralExpression(
                                                                    SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(@"Sample"))
                                        )})))));
                        root = root.ReplaceNodes(descentants, (node, n2) => attributeList);
                        solution = solution.WithDocumentSyntaxRoot(document.Id, root);
                    }
                }
            }
            return solution;
        }
    }
