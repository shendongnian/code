    class MyClass
    {
        [JsonConverter(typeof(TemplateConverter))]
        public Template Template { get; set; }
    }
    class Template
    {
        /* Your Template class */
        public Type TypeToSerializeInto { get; private set; }
    }
    public class TemplateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) 
        { 
            return objectType == typeof(Template);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) { }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
        { 
            Template val = value as Template;
            
            writer.WriteStartObject();
            writer.WritePropertyName("Template");
            if (val.TypeToSerializeInto == typeof(Template))
                serializer.Serialize(writer, val);
            else if (val.TypeToSerializeInto == typeof(string))
                serializer.Serialize(writer, val.Name);
            writer.WriteEndObject();
        }
    }
