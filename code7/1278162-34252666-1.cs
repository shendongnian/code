    public interface IMessageQueue
    {
        void AddToQueue(int element);
    }
    public interface IMessageSender
    {
        void SendMessage(object message);
    }
    public class SenderClass : IMessageQueue
    {
        private readonly IMessageSender _sender;
        public SenderClass(IMessageSender sender)
        {
            _sender = sender;
        }
        public void AddToQueue(int element)
        {
            /*...*/
        }
        private void SendMessage()
        {
            _sender.SendMessage(new object());
        }
    }
    public class DummyMessageSender : IMessageSender
    {
        //you can use this in your test harness to check for the messages sent
        public Queue<object> Messages { get; private set; }
        public DummyMessageSender()
        {
            Messages = new Queue<object>();
        }
        public void SendMessage(object message)
        {
            Messages.Enqueue(message);
            //obviously you'll need to do some locking here too
        }
    }
