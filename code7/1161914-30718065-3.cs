    public class MimeHeaderConverter : JsonConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject obj = serializer.Deserialize<JObject>(reader);
            
            HeaderId headerId = obj["Id"].ToObject<HeaderId>();
            
            Header header = new Header(headerId, obj["Value"].ToObject<string>());
            
            return header;
        }
        
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override bool CanConvert(Type t)
        {
            return typeof(Header).IsAssignableFrom(t);
        }
        
        public override bool CanRead { get { return true; } }
        public override bool CanWrite { get { return false; } }
    }
