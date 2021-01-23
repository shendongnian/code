    public class SomeOuterObject
    {
        public string stringValue { get; set; }
        [ChoTypeConverter(typeof(ToTextConverter))]
        public IPAddress ipValue { get; set; }
    }
