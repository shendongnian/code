    public class CacheableOperationAttribute : Attribute, IOperationBehavior
    {
        // omitting lots of code...
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new CachingOperationInvoker(dispatchOperation.Invoker, this.secondsToCache);
        }
    }
