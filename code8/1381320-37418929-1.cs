    class Foo
    {
        [JsonConverter(typeof(WrappedStringConverter))]
        public string MyRootAttr { get; set; }
    }
