    public enum EnumV1
    {
        Default = 0,
        One = 1,
        Two = 2
    }
    public enum EnumV2
    {
        Default = 0,
        One = 1,
        Two = 2,
        Three = 3 // <- newly added
    }
    [ProtoContract]
    public class ClassV1
    {
        [ProtoMember(1)]
        public string ValueAsString
        {
            get { return Value.ToString(); }
            set
            {
                try
                {
                    Value = (EnumV1) Enum.Parse(typeof (EnumV1), value);
                }
                catch (Exception)
                {
                    Value = EnumV1.Default;
                }
            }
        }
        public EnumV1 Value { get; set; }
    }
    [ProtoContract]
    public class ClassV2
    {
        [ProtoMember(1)]
        public string ValueAsString
        {
            get { return Value.ToString(); }
            set
            {
                try
                {
                    Value = (EnumV2)Enum.Parse(typeof(EnumV2), value);
                }
                catch (Exception)
                {
                    Value = EnumV2.Default;
                }
            }
        }
        public EnumV2 Value { get; set; }
    }
