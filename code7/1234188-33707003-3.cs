    private static void AnalyzeSyntaxTree(SyntaxNodeAnalysisContext context)
            {
                if (context.Node.IsKind(SyntaxKind.SimpleAssignmentExpression))
                {
                    var assign = (AssignmentExpressionSyntax)context.Node;
                    var leftType = context.SemanticModel.GetTypeInfo(assign.Left).GetType();
                    var attr = leftType.GetCustomAttributes(typeof(MinMaxSizeAttribute), false).OfType<MinMaxSizeAttribute>().FirstOrDefault();
                    if (attr != null && assign.Right.IsKind(SyntaxKind.NumericLiteralExpression))
                    {
                        var numLitteral = (LiteralExpressionSyntax)assign.Right;
                        var t = numLitteral.Token;
                        if (t.Value.GetType().Equals(typeof(int)))
                        {
                            var intVal = (int)t.Value;
                            if (intVal > attr.MaxVal || intVal < attr.MaxVal)
                            {
                                Diagnostic.Create(Rule, assign.GetLocation(), leftType.Name);
                            }
                        }
                    }
                }
            }
