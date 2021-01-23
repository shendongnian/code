    public abstract class HandlerBase<T> : IMessageHandler<T>
    {
        public abstract void Handle(Monkey message);
       
        void IMessageHandler.Handle(object message)
        {
            Handle((T)message);
        }
    }
    public class MonkeyHandler : HandlerBase<Monkey>
    {
        public override void Handle(Monkey message) 
        {
        }
    }
