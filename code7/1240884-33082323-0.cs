    class MyClass
    {
        [JsonConverter(typeof(TemplateConverter))]
        public Template Template { get; set; }
    }
    class Template
    {
        /* Your Template class */
        public Type SerializedType { get; private set; }
    }
    public class FooConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) { return true; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) { }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
        { 
            Template val = value as Template;
            if (val.Type == typeof(Template))
                // Serialize val
            else if (val.Type == typeof(string))
                // Serialize val.Name
        }
    }
