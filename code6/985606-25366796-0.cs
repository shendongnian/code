    public class Counter : ExpressionVisitor
    {
        private Func<Expression, bool> predicate;
        public int Count { get; private set; }
        public Counter(Func<Expression, bool> predicate)
        {
            this.predicate = predicate;
        }
        public override Expression Visit(Expression node)
        {
            if (predicate(node))
                Count++;
            return base.Visit(node);
        }
    }
    public static int Count(
        this Expression expression, 
        Func<Expression, bool> predicate)
    {
        var counter = new Counter(predicate);
        counter.Visit(expression);
        return counter.Count;
    }
