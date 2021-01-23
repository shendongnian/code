    public class OperationParser : ExpressionVisitor
    {
        public OperationParser()
        {
            Expressions = new List<BinaryExpression>();
        }
        public List<BinaryExpression> Expressions { get; private set; }  
        protected override Expression VisitBinary(BinaryExpression b)
        {
            Expressions.Add(b);
            return base.VisitBinary(b);
        }
    }
