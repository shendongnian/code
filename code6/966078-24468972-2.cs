    public class LogicalScope : IDisposable
    {
        public static CurrentId
        {
            get
            {
                return (Guid)Trace.CorrelationManager.LogicalOperationStack.Peek();
            }
        }
        public LogicalScope()
        {
            Id = Guid.NewGuid();
            Trace.CorrelationManager.StartLogicalOperation(Guid.NewGuid())
        }
        public void IDisposable.Dispose()
        {
             Trace.CorrelationManager.StopLogicalOperation()
        }
    }
    
