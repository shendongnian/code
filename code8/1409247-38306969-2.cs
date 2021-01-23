    public List<LambdaExpression> Expressions { get; set; } = new List<LambdaExpression>();
    foreach (LambdaExpression expression in Expressions)
    {
        var inType = expression.Paramters[0].Type;
        var outType = expresssion.ReturnType;
    }
