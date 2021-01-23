    public class MaterialArrayConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                JToken results = token["results"];
                if (results != null && results.Type == JTokenType.Array)
                {
                    return results.ToObject<List<Material>>(serializer);
                }
                else if (results == null)
                {
                    return new List<Material> { token.ToObject<Material>(serializer) };
                }
            }
            throw new JsonSerializationException("Unexpected JSON format encountered in MaterialArrayConverter: " + token.ToString());
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when [JsonConverter] attribute is used
            return false;
        }
    }
