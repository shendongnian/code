    class ExpressionSubstitute : ExpressionVisitor
    {
        private readonly Expression _from;
        private readonly Expression _to;
        public ExpressionSubstitute(Expression from, Expression to)
        {
            _from = from;
            _to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == _from ? _to : base.Visit(node);
        }
    }
