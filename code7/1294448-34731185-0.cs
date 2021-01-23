    public class NumberAndSecondaryStatConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(NumberAndSecondaryStat);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader).SelectToken("item");
            if (token == null)
                return null;
            var value = (existingValue as NumberAndSecondaryStat) ?? new NumberAndSecondaryStat();
            value.DataItems = token.OfType<JObject>().Select(o => o.ToObject<DataItem>()).ToArray();
            value.TrendData = token.OfType<JArray>().SelectMany(a => a.Select(i => (string)i)).ToList();
            return value;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stat = (NumberAndSecondaryStat)value;
            serializer.Serialize(writer, new { item = (stat.DataItems ?? Enumerable.Empty<object>()).Concat(new[] { stat.TrendData ?? Enumerable.Empty<string>() }) });
        }
    }
