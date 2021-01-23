    public class ChatEntity
    {
        public string Member { get; set; }
        public ObservableCollection<MessageEntity> MessageList { get; set; }
    }
    
    public class MessageEntity
    {
        public enum MsgType
        {
            From,
            To
        }
    
        public string Member { get; set; }
        public string Content { get; set; }
        public MsgType MessageType { get; set; }
    }
