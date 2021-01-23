        static void Main(string[] args)
        {
            var result = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseFile(@"..\..\Test.cs");
            var root = result.GetRoot();
            
            var exceptionNodes = FindCatchNodes(root);
            foreach (var node in exceptionNodes)
            {
                var line = node.GetLocation().GetLineSpan().StartLinePosition.Line + 1;
                if (IsTotallyEmptyCatch(node))
                {
                    Console.WriteLine("Totally empty catch: line {0}", line);
                }
                if (JustRethrows(node))
                {
                    Console.WriteLine("Pointless rethrow: line {0}", line);
                }
            }
        }
        static List<SyntaxNodeOrToken> FindCatchNodes(SyntaxNodeOrToken node)
        {
            var exceptions = new List<SyntaxNodeOrToken>();
            var isCatchBlock = node.IsKind(SyntaxKind.CatchClause);
            if (isCatchBlock)
            {
                exceptions.Add(node);
            }
            foreach (var result in node.ChildNodesAndTokens().Select(FindCatchNodes).Where(result => result != null))
            {
                exceptions.AddRange(result);
            }
            return exceptions;
        }
        static bool IsTotallyEmptyCatch(SyntaxNodeOrToken catchBlock)
        {
            var block = catchBlock.ChildNodesAndTokens().First(t => t.CSharpKind() == SyntaxKind.Block);
            var children = block.ChildNodesAndTokens();
            return (children.Count == 2 && children.Any(c => c.CSharpKind() == SyntaxKind.OpenBraceToken) &&
                    children.Any(c => c.CSharpKind() == SyntaxKind.CloseBraceToken));
        }
        static bool JustRethrows(SyntaxNodeOrToken catchBlock)
        {
            var block = catchBlock.ChildNodesAndTokens().First(t => t.CSharpKind() == SyntaxKind.Block);
            var children = block.ChildNodesAndTokens();
            return (children.Count == 3 && children.Any(c => c.CSharpKind() == SyntaxKind.OpenBraceToken) &&
                    children.Any(c => c.CSharpKind() == SyntaxKind.CloseBraceToken) && children.Any(c=>c.CSharpKind() == SyntaxKind.ThrowStatement));
        } 
