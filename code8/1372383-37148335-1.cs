    [Message(MessageType.FirstMessage)]
    [ProtoContract]
    class MyFirstMessage {
        [ProtoMember(1)]
        public string Value { get; set; }
        [ProtoMember(2)]
        public int AnotherValue { get; set; }
    }
    [Message(MessageType.SecondMessage)]
    [ProtoContract]
    class MySecondMessage {
        [ProtoMember(1)]
        public decimal Stuff { get; set; }
    }
