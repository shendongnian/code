    [ProtoContract]
    public class ClassV1
    {
        [ProtoMember(1), DefaultValue(EnumV1.Default)]
        public EnumV1 Value { get; set; }
    }
