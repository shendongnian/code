    public class MyModelJsonConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return false; }
        }
        
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyModel);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            
            var model = value as MyModel;
            if (model == null) throw new JsonSerializationException();
            
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue(model.Name);
            writer.WritePropertyName("details");
            writer.WriteStartObject();
            writer.WritePropertyName("size");
            serializer.Serialize(writer, model.Size);
            writer.WritePropertyName("weight");
            writer.WriteValue(model.Weight);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
    
    [JsonConverter(typeof(MyModelJsonConverter))]
    public class MyModel
    {
        public string Name { get; set; }
        public string[] Size { get; set; }
        public string Weight { get; set; }
    }
