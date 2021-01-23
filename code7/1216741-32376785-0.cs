    [DataContract]
    public class MyMessage : MyMessageBase
    {
        [DataMember]
        public Guid MessageID { get; set; }
        public MyMessage(Guid messageId, int messageType, int enabled)
            : base(messageType, enabled)
        {
            MessageID = messageId;
        }
        public MyMessage() { }
    }
    
