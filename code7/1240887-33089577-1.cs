    class MyClass
    {
        [JsonConverter(typeof(TemplateOrStringConverter))]
        public object Template { get; set; }
    }
