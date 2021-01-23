    [AttributeUsageAttribute(AttributeTargets.All)]
    public class DescriptionWithValueAttribute : DescriptionAttribute
    {
        public DescriptionWithValueAttribute(string description, string value) : base(description)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
    }
