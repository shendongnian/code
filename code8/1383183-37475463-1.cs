    public class PipelineInterceptor : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get { return OperationContext.Current != null; }
        }
        // Other ...
    }
