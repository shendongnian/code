    class WhileConditionRefactoringVisitor : CSharpSyntaxRewriter
    {
        private static int CONDITION_COUNTER = 0;
        private static string CONDITION_VAR = "whileCondition_";
        private static string ConditionIdentifier
        {
            get { return CONDITION_VAR + CONDITION_COUNTER++; }
        }
        private readonly List<SyntaxNode> markedNodes = new List<SyntaxNode>();
        private readonly List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax, WhileStatementSyntax>> replacementNodes =
            new List<Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax, WhileStatementSyntax>>();
    
            //STEP 1
            public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            var nodeVisited = (WhileStatementSyntax) base.VisitWhileStatement(node);
            
            var condition = nodeVisited.Condition;
            if (condition.Kind() == SyntaxKind.IdentifierName)
                return nodeVisited;
                     
            string conditionVarIdentifier = ConditionIdentifier;
            var newConditionVar = SyntaxFactoryExtensions.GenerateLocalVariableDeclaration(conditionVarIdentifier,
                condition, SyntaxKind.BoolKeyword).NormalizeWhitespace().WithTriviaFrom(nodeVisited);
            var newCondition = SyntaxFactory.IdentifierName(conditionVarIdentifier).WithTriviaFrom(condition);
            markedNodes.Add(condition);
            markedNodes.Add(node);
            replacementNodes.Add(new Tuple<ExpressionSyntax, IdentifierNameSyntax, StatementSyntax, WhileStatementSyntax>(condition, newCondition, newConditionVar, node));
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
                    var whileStatement = currentA.Parent;
                    oldBody = oldBody.InsertNodesBefore(whileStatement, new List<SyntaxNode>() { tuple.Item3 });
                    var currentB = oldBody.GetCurrentNode(tuple.Item1);
                    oldBody = oldBody.ReplaceNode(currentB, tuple.Item2);
                    var currentWhile = oldBody.GetCurrentNode(tuple.Item4);
                    //modify body
                    var whileBody = currentWhile.Statement as BlockSyntax;
                    //create new statement
                    var localCondition = tuple.Item3 as LocalDeclarationStatementSyntax;
                    var initializer = localCondition.Declaration.Variables.First();
                    var assignment = SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                        SyntaxFactory.IdentifierName(initializer.Identifier), initializer.Initializer.Value));
                    var newStatements = whileBody.Statements.Add(assignment);
                    whileBody = whileBody.WithStatements(newStatements);
                    //updateWhile
                    var newWhile = currentWhile.WithStatement(whileBody);
                    oldBody = oldBody.ReplaceNode(currentWhile, newWhile);
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
