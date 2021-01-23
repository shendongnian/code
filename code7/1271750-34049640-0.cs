    public interface IMessageHandler<T>
    {
        void Handle(T message);
    }
    public class MonkeyHandler : IMessageHandler<Monkey>
    {
        public void Handle(Monkey message) {}
    }
