    public class Message
    {
        public void int MessageId {get; set;}
        public void string UserMessage {get; set;}
    
        public override string ToString()
        {
            return UserMessage;
        }
    }
