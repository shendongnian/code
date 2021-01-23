    public class AttributeBase
    {
        public string Key { get; set; }
    }
    public class Attribute<TValue> : AttributeBase
    {
        public TValue Value { get; set; }
    }
