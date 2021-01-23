    public interface IMessageHandler<TMessage>
    {
        void Handle(TMessage msg);
    }
    
    public class SomeService : IMessageHandler<UserCreated>
    {
        //[.. all other methods ..]
    
        public void Handle(UserCreated msg)
        {
            // ...
        }
    }
