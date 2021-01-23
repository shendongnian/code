    /// <summary>
    /// Partially apply a value to an expression
    /// </summary>
    public static Expression<Func<U, bool>> Apply<T, U>(this Expression<Func<T, U, bool>> input, T value)
    {
       var swap = new ExpressionSubstitute(input.Parameters[0], Expression.Constant(value));
        var lambda = Expression.Lambda<Func<U, bool>>(swap.Visit(input.Body), input.Parameters[1]);
       return lambda;
    }
    class ExpressionSubstitute : System.Linq.Expressions.ExpressionVisitor
    {
        private readonly Expression from, to;
        public ExpressionSubstitute(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            if (node == from) return to;
            return base.Visit(node);
        }
    }
