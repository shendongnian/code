    class Foo
    {
        ...
        [JsonConverter(typeof(RawJsonConverter))]
        public string YourJsonProperty { get; set; }
        ...
    }
