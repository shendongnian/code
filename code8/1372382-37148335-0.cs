    enum MessageType : byte {
        FirstMessage,
        SecondMessage
    }
    class MessageAttribute : Attribute {
        public MessageAttribute(MessageType type) {
            Type = type;
        }
        public MessageType Type { get; private set; }
    }
