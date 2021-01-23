    public class ProcessingVisitor : ExpressionVisitor
    {
        IProcessor _processor;
        public string Result { get; private set; }
        public ProcessingVisitor(IProcessor processor)
        {
            _processor = processor;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            // visit left and right
            // ... and do something with _processor
            Result += "";// ... append something to result
            return node;
        }
        public Expression VisitFresh(Expression e)
        {
            Result = null;
            return Visit(e);
        }
    }
