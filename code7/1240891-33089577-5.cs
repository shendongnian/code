    class MyClass
    {
        [JsonConverter(typeof(ObjectOrStringConverter<Template>))]
        public object Template { get; set; }
    }
