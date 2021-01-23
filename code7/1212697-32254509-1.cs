    public interface INotifier
    {
        IList<MessageSystem> Messages { get; }
        void AddMessage(MessageType type, string Message);
    }
    /**
     * public class Notifier : INotifier
     * 
     * Purpose: Main class which will take care of adding the messages for us.
     * 
     * */
    public class Notifier : INotifier
    {
        //List of messages so we can display multiple for the user.
        public IList<MessageSystem> Messages { get; private set; }
        public Notifier()
        {
            Messages = new List<MessageSystem>();
        }
        //Adds the message to the current Messages variable. 
        public void AddMessage(MessageType type, string Message)
        {
            Messages.Add(new MessageSystem
            {
                Type = type,
                Message = Message
            });
        }
    }
