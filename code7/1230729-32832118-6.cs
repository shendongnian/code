    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ValueMember : System.Attribute
    {
        public string Value { get; private set; }
        public ValueMember(string valueMember)
        {
            this.Value = valueMember;
        }
    }
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DisplayMember : System.Attribute
    {
        public string Value { get; private set; }
        public DisplayMember(string displayMember)
        {
            this.Value = displayMember;
        }
    }
