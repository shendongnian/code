    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Conversation> Conversations { get; set; }
    }
    
    public class Conversation
    {
        public int ID { get; set; }
        public int RecipientUserID { get; set; }
        public User RecipientUser { get; set; }
        public int SenderUserID { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
    
    public class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int ConversationID { get; set; }
        public Conversation Conversation { get; set; }
    }
