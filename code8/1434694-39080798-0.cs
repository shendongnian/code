    public decimal Evaluate(string expression)
    {
        if (String.IsNullOrWhiteSpace(expression))
            throw new ArgumentException("Parameter " + nameof(expression) + " cannot be empty");
        return EvaluateReversePolishExpression(expression);
    }
