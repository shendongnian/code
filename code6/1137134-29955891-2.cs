    using NumFunc = System.Func<double>;
    using NumExpr = System.Linq.Expressions.Expression<System.Func<double>>;
    ...
    static NumExpr Square(NumExpr operand)
    {
        return Product(operand, operand);
    }
    static NumExpr Product(NumExpr left, NumExpr right)
    {
        return Expression.Lambda<NumFunc>(Expression.Multiply(left.Body, right.Body));
    }
