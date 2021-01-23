    public class ConvertableExpression<T>
    {
        public ConvertableExpression(Expression<Func<T, object>> expr)
        {
            this.Expression = expr;
        }
        public Expression<Func<T, object>> Expression { get; private set; }
    }
