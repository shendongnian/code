    public class SimpleParameterReplacer : ExpressionVisitor
    {
        public readonly ReadOnlyCollection<ParameterExpression> From;
        public readonly ReadOnlyCollection<ParameterExpression> To;
        public SimpleParameterReplacer(ParameterExpression from, ParameterExpression to)
            : this(new[] { from }, new[] { to })
        {
        }
        public SimpleParameterReplacer(IList<ParameterExpression> from, IList<ParameterExpression> to)
        {
            if (from == null || from.Any(x => x == null))
            {
                throw new ArgumentNullException("from");
            }
            if (to == null || to.Any(x => x == null))
            {
                throw new ArgumentNullException("to");
            }
            if (from.Count != to.Count)
            {
                throw new ArgumentException("to");
            }
            // Note that we should really clone from and to... But we will
            // ignore this!
            From = new ReadOnlyCollection<ParameterExpression>(from);
            To = new ReadOnlyCollection<ParameterExpression>(to);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            int ix = From.IndexOf(node);
            if (ix != -1)
            {
                node = To[ix];
            }
            return base.VisitParameter(node);
        }
    }
