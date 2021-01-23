    public class ByteArrayConverter : JsonConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            string base64String = Convert.ToBase64String((byte[])value);
            
            serializer.Serialize(writer, base64String);
        }    
        
        public override bool CanRead
        {
            get { return false; }
        }
        
        public override bool CanConvert(Type t)
        {
            return typeof(byte[]).IsAssignableFrom(t);
        }
    }
