    public class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _original;
        private readonly Expression _replacement;
    
        public ReplaceExpressionVisitor(Expression original, Expression replacement)
        {
            _original = original;
            _replacement = replacement;
        }
    
        public override Expression Visit(Expression node)
        {
            return node == _original ? _replacement : base.Visit(node);
        }
    }
