    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class MessageSenderAttribute : ExportAttribute
    {
        public MessageSenderAttribute() : base(typeof(IMessageSender)) { }
        public MessageTransport Transport { get; set; }
        public bool IsSecure { get; set; }
    }
