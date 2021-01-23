    public class Example
    {
        public int TypedProperty { get; set; }
        [JsonConverter(typeof(UntypedToTypedValueConverter))]
        public object UntypedProperty { get; set; }
    }
