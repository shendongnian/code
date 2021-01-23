    public class MessageWrapper<T>
    {
        public string MessageType { get { return typeof(T).FullName; } }
        public T Message { get; set; }
    }
