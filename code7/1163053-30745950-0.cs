    // class to be serialized
    public class MyClass
    {
        [JsonProperty(ItemConverterType = typeof(JavaScriptDateTimeConverter))]
        public DateTime? DateTime1;
        public DateTime? DateTime2;
    }
