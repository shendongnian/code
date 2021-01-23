    public class CachingOperationInvoker : IOperationInvoker
    {
        // omitting lots of code...
        public CachingOperationInvoker(IOperationInvoker originalInvoker, double cacheDuration)
        {
            this.originalInvoker = originalInvoker;
            this.cacheDuration = cacheDuration;
        }
    }
