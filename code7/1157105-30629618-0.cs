    class IfConditionRefactoringVisitor : CSharpSyntaxRewriter
        {
            private static int CONDITION_COUNTER = 0;
            private static string CONDITION_VAR = "condition_";
    
            private static string ConditionIdentifier
            {
                get { return CONDITION_VAR + CONDITION_COUNTER++; }
            }
    
            private readonly List<ExpressionSyntax> markedNodes = new List<ExpressionSyntax>();
    
            private readonly List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>> replacementNodes =
                new List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>>();
    
            //STEP 1
            public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
            {
                var nodeVisited = (IfStatementSyntax) base.VisitIfStatement(node);
                
                var condition = nodeVisited.Condition;
                if (condition.Kind() == SyntaxKind.IdentifierName)
                    return nodeVisited;
                
                //TODO: invert condition
    
                string conditionVarIdentifier = ConditionIdentifier;
                var newConditionVar = SyntaxFactoryExtensions.GenerateLocalVariableDeclaration(conditionVarIdentifier,
                    condition, SyntaxKind.BoolKeyword).NormalizeWhitespace().WithTriviaFrom(nodeVisited);
                var newCondition = SyntaxFactory.IdentifierName(conditionVarIdentifier).WithTriviaFrom(condition);
    
                markedNodes.Add(condition);
                replacementNodes.Add(new Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax>(condition, newCondition, newConditionVar));
    
                return nodeVisited;
            }
    
            //STEP 2
            private BlockSyntax ReplaceNodes(BlockSyntax oldBody)
            {
                oldBody = oldBody.TrackNodes(this.markedNodes);
                foreach (var tuple in this.replacementNodes)
                {
                    var currentA = oldBody.GetCurrentNode(tuple.Item1);
                    if (currentA != null)
                    {
                        var ifStatement = currentA.Parent;
                        oldBody = oldBody.InsertNodesBefore(ifStatement, new List<SyntaxNode>() { tuple.Item3});
                        var currentB = oldBody.GetCurrentNode(tuple.Item1);
                        oldBody = oldBody.ReplaceNode(currentB, tuple.Item2);
                    }
                }
                return oldBody;
            }
    
            public BlockSyntax Refactor(BlockSyntax oldBody)
            {
                markedNodes.Clear();
                replacementNodes.Clear();
                //STEP 1
                oldBody = (BlockSyntax)this.Visit(oldBody);
                //STEP 2
                oldBody = this.ReplaceNodes(oldBody);
    
                return oldBody;
            }
    
        }
