    public class StringToIntEnumerable : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override bool CanWrite
        {
            get
            {
                return false;    // we'll stick to read-only. If you want to be able 
                                 // to write it isn't that much harder to do.
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Note: I've skipped over a lot of error checking and trapping here
            // but you might want to add some
            var str = reader.Value.ToString();
            return str.Split(',').Select(s => int.Parse(s));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
