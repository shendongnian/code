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
                    // we've got multiple items; deserialize to a list
                    return results.ToObject<List<Material>>(serializer);
                }
                else if (results == null)
                {
                    // "results" property not present; return a list of one item
                    return new List<Material> { token.ToObject<Material>(serializer) };
                }
            }
            // some other format we're not expecting
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
