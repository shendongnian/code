    public class EventHub
    {
        // only one receiver per message type is allowed to simplify an example
        private static readonly ConcurrentDictionary<MessageTypes, IReceiver> receivers = 
            new ConcurrentDictionary<MessageTypes, IReceiver>();
        public bool TrySubscribe(MessageTypes messageType, IReceiver receiver)
        {
            return receivers.TryAdd(messageType, receiver);
        }
        public void Publish(IMessage message)
        {
            IReceiver receiver;
            if (receivers.TryGetValue(message.MessageType, out receiver))
            {
                receiver.Receive(message);
            }
        }
    }
    public interface IMessage
    {
        MessageTypes MessageType { get; }
        string Text { get; set; }
    }
    public interface IReceiver
    {
        void Receive(IMessage message);
    }
