    // handlers should be differentiated by message type
    public class SomethingHappenedMessage
    {
        public float A { get; set; }
        public int B { get; set; }
    }
    public class Mediator
    {
        private readonly Dictionary<Type, object> _dict = new Dictionary<Type, object>();
        public void Register<Tmessage>(Action<Tmessage> callback)
        {
            _dict[typeof(Tmessage)] = callback;
        }
        public void Dispatch<Tmessage>(Tmessage msg)
        {
            var handler = _dict[typeof(Tmessage)] as Action<Tmessage>;
            handler(msg);
        }
    }
