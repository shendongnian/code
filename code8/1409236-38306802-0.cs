    void Main()
    {
        string input = "y + 3 * Sin(x)";
        var options = CSharpParseOptions.Default.WithKind(Microsoft.CodeAnalysis.SourceCodeKind.Script);
        var expression = CSharpSyntaxTree.ParseText(input, options).GetRoot().DescendantNodes().OfType<ExpressionStatementSyntax>().FirstOrDefault()?.Expression;
        Console.WriteLine(EvaluateExpression(expression));
    }
    Complex EvaluateExpression(ExpressionSyntax expr)
    {
        if (expr is BinaryExpressionSyntax)
        {
            var binExpr = (BinaryExpressionSyntax)expr;
            var left = EvaluateExpression(binExpr.Left);
            var right = EvaluateExpression(binExpr.Right);
            switch (binExpr.OperatorToken.ValueText)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    return left / right;
                default:
                    throw new NotSupportedException(binExpr.OperatorToken.ValueText);
            }
        }
        else if (expr is IdentifierNameSyntax)
        {
            return GetValue(((IdentifierNameSyntax)expr).Identifier.ValueText);
        }
        else if (expr is LiteralExpressionSyntax)
        {
            var value = ((LiteralExpressionSyntax)expr).Token.Value;
            return float.Parse(value.ToString());
        }
        else if (expr is InvocationExpressionSyntax)
        {
            var invocExpr = (InvocationExpressionSyntax)expr;
            var args = invocExpr.ArgumentList.Arguments.Select(arg => EvaluateExpression(arg.Expression)).ToArray();
            return Call(((IdentifierNameSyntax)invocExpr.Expression).Identifier.ValueText, args);
        }
        else
            throw new NotSupportedException(expr.GetType().Name);
    }
    Complex Call(string identifier, Complex[] args)
    {
        switch (identifier.ToLower())
        {
            case "sin":
                return Complex.Sin(args[0]);
            default:
                throw new NotImplementedException(identifier);
        }
    }
    Complex GetValue(string identifier)
    {
        switch (identifier)
        {
            case "x":
                return new Complex(1, 0);
            case "y":
                return new Complex(0, 1);
            default:
                throw new ArgumentException("Identifier not found", nameof(identifier));
        }
    }
