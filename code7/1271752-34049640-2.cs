    public interface IMessageHandler
    {
        void Handle(object message);
    }
    public interface IMessageHandler<T> : IMessageHandler
    {
        void Handle(T message);
    }
    public class MonkeyHandler : IMessageHandler<Monkey>
    {
        public void Handle(Monkey message) {}
       
        //hide from the public API
        void IMessageHandler.Handle(object message)
        {
            Handle((Monkey)message);
        }
    }
