    public class ProcessorWrapper<T> : IMessageProcessor<IBaseMessage> {
        private readonly IMessageProcessor<T> inner;
        public ProcessorWrapper(IMessageProcessor<T> inner) { this.inner = inner; }
    
        public void Process(IBaseMessage msg)
        {
            if(msg is T) { inner.Process((T)msg); }
            else throw new ArgumentException("Invalid message type");
        }
    }
