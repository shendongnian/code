    public class MessageService : IMessageService
    {
        private List<String> messages = new List<String> ();
        public void AddMessageToSession(string msg)
        {
            messages.Add(msg);
        }
        public List<string> ListSessionMessages()
        {
            return messages;
        }
    }
