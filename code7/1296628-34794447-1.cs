    public class ProcessingVisitor : ExpressionVisitor
    {
        IProcessor _processor;
        private Expression _rootExpression = null;
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
        public override Expression Visit(Expression node)
        {
            if (_rootExpression == null)
            {
                _rootExpression = node;
                Result = null;
            }
            var toReturn = base.Visit(node);
            if (_rootExpression == node)
                _rootExpression = null;
            return toReturn;
        }
    }
