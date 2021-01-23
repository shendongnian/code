        private string GetDllName(AttributeSyntax importAttribute, Compilation compilation)
        {
            var expression = importAttribute.ArgumentList.Arguments[0].Expression;
            return GetConstantValue(expression, compilation);
        }
        private string GetConstantValue(ExpressionSyntax expression, Compilation compilation)
        {
            if (expression.IsKind(SyntaxKind.StringLiteralExpression))
            {
                var literal = expression as LiteralExpressionSyntax;
                return literal.Token.ValueText;
            }
            else if (expression.IsKind(SyntaxKind.AddExpression))
            {
                var binaryExpression = expression as BinaryExpressionSyntax;
                return GetConstantValue(binaryExpression.Left, compilation) +
                    GetConstantValue(binaryExpression.Right, compilation);
            }
            else
            {
                var model = compilation.GetSemanticModel(expression.SyntaxTree);
                var symbol = model.GetSymbolInfo(expression).Symbol;
                var defNode = symbol.DeclaringSyntaxReferences.First().GetSyntax();
                var valueClause = defNode.DescendantNodes().OfType<EqualsValueClauseSyntax>().FirstOrDefault();
                if (valueClause != null)
                {
                    return GetConstantValue(valueClause.Value, compilation);
                }
                else
                {
                    return "Unknown";
                }
            }
        }
