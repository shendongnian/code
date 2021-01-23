    public class BadDataEntityConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(BadDataEntity).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Note that BadData MUST BE VALID JSON, otherwise this won't work.
            var token = JToken.Load(reader);
            var bad = (existingValue as BadDataEntity ?? new BadDataEntity());
            bad.BadData = JsonConvert.SerializeObject(token, Formatting.Indented);
            return bad;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bad = (BadDataEntity)value;
            if (bad.BadData == null)
                writer.WriteNull();
            else
            {
                var token = JToken.Parse(bad.BadData);
                token.WriteTo(writer, serializer.Converters.ToArray());
            }
        }
    }
