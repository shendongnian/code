    public class ProcessingVisitor : ExpressionVisitor
    {
        IProcessor _processor;
        #region Inner Class
        internal class _Implementation : ExpressionVisitor
        {
            IProcessor _processor;
            internal string Result { get; set; }
            internal _Implementation(IProcessor processor)
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
            internal Expression VisitFresh(Expression node)
            {
                Result = null;
                return base.Visit(node);
            }
        }
        #endregion
        public string Result { get; private set; }
        public ProcessingVisitor(IProcessor processor)
        {
            _processor = processor;
        }
        public override Expression Visit(Expression node)
        {
            var impl = new _Implementation(_processor);
            var toReturn = impl.VisitFresh(node);
            Result = impl.Result;
            return toReturn;
        }
    }
