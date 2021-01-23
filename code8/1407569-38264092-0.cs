    public class Conversation
    {
        public int ID { get; set; }
        public int SenderUserID { get; set; }
        public User SenderUser { get; set;}
        public int RecipientUserID { get; set; }
        public User RecipientUser { get; set; }
    }
