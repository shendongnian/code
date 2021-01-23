    class OptionsExtractor:ExpressionVisitor
    {
        public IEnumerable<Expression> Extract(Expression expression, List<Dictionary<JoinOptionsExpression,int>> selections)
        {
            foreach(var selection in selections)
            {
                currentSelections = selection;
                yield return Visit(expression);
            }
        }
        private Dictionary<JoinOptionsExpression,int> currentSelections;
        override Expression Visit(Expression node)
        {
            var opts = node as JoinOptionsExpression;
            if (opts != null)
                return base.Visit(opts.Options.ElementAt(currentSelections[opts]);
            else
                return base.Visit(node);
        }
    }
