     protected override void Analyze(SyntaxNodeAnalysisContext context)
            {
                NodeToAnalyze = context.Node;
            var varDeclareSyntax = (LocalDeclarationStatementSyntax)NodeToAnalyze;
            if (varDeclareSyntax == null) return;
            var variableDeclare = varDeclareSyntax.ChildNodes().OfType<VariableDeclarationSyntax>().FirstOrDefault();
            if (variableDeclare == null) return;
            var varDeclarator = variableDeclare.ChildNodes().OfType<VariableDeclaratorSyntax>().FirstOrDefault();
            if (varDeclarator == null) return;
            //var identifierToken = varDeclarator.Identifier.Text; //  <- here we find [item] in ( var item=expression; )
            var method = varDeclarator.GetSingleAncestor<MethodDeclarationSyntax>();
            var varDeclaratorIndex = method.DescendantNodes().OfType<CSharpSyntaxNode>().IndexOf(varDeclarator);
            var allNodes = method.DescendantNodes().OfType<CSharpSyntaxNode>().Select((node, index) => new Node
            {
                Index = index,
                Syntax = node,
                Location = node.GetLocation(),
                Kind = node.Kind(),
                Ancestors = node.Ancestors()
            }).ToArray();
            var maxIndex = allNodes.Where(it => it.Ancestors.Any(x => x == varDeclarator)).Max(it => it.Index.Value);
            if (maxIndex >= allNodes.Length) return;
            var nextReturn = allNodes[maxIndex + 1];
            if (nextReturn.Kind != SyntaxKind.ReturnStatement) return;
            var @return = nextReturn.Syntax as ReturnStatementSyntax;
            if ((@return.Expression as IdentifierNameSyntax)?.Identifier.ValueText == varDeclarator.Identifier.ValueText)
            {
                ReportDiagnostic(context, varDeclareSyntax);
            }
        }
        protected override RuleDescription GetDescription()
        {
            return new RuleDescription
            {
                ID = "176",
                Category = Category.Design,
                Message = "Variable declaration is unnecessary due to it used only for return statement"
            };
        }
        private class Node : NodeDefinition
        {
            public IEnumerable<SyntaxNode> Ancestors { get; set; }
            public SyntaxNode Syntax { get; set; }
            public SyntaxKind Kind { get; set; }
        }
