    public class JsonStringListConverter: JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            List<string> items = new List<string>();
            if(reader.TokenType == JsonToken.String)
            {
                string value = reader.Value.ToString();
                items.Add(value);
            }
            if(reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                do
                {
                    string value = reader.Value.ToString();
                    items.Add(value);
                    reader.Read();
                } while (reader.TokenType != JsonToken.EndArray);
            }
            return (items.Count = 0) ? null : items;
        }
        
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IList<string>));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
