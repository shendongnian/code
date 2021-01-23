    public class MyUserAuth : UserAuth
    {
        [Ignore]
        public List<TextMessage> TextMessagesAsAuthor { get; set; }
    
        [Ignore]
        public List<TextMessage> TextMessagesAsRecipient { get; set; }
    }
