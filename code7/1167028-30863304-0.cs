    public interface IPromise
    {
        void Complete(ByteQueue data);
    }
    public class Promise<T> : IPromise
    {
        public ManualResetEvent ResetEvent = new ManualResetEvent (false);
        public T ReturnValue {get; private set;}
        private object syncObject = new object();
        public void Complete(ByteQueue data)
        {
            ReturnValue = data.GetReturnValue();
            ResetEvent.Set();
        }
    }
