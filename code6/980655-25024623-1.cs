    [ProtoContract]
    public class RequestMessage
    {
        [ProtoMember(1)]
        public int Number1 { get; set; }
        [ProtoMember(2)]
        public int Number2 { get; set; }
    }
