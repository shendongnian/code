    [XmlRoot("Message")]
    public class MessageText : Message
    {
        public MessageText(Guid from, Guid to, MessageType type, DateTime sentAt, string text)
            : base(from, to, type, sentAt)
        {
            this.Text = text;
        }
    
        public MessageText()
        {
        }
    
        public string Text { get; set; }
    }
