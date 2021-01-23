    class MarkLogicMatchEntryConverter : JsonConverter
    {
        JsonSerializer GetEnumSerializer()
        {
            return JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = new[] { new StringEnumConverter { CamelCaseText = true } } });
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MarkLogicMatchEntry);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            else if (reader.TokenType == JsonToken.String)
            {
                return new MarkLogicMatchEntry { MatchType = MatchType.Normal, Value = reader.Value.ToString() };
            }
            else
            {
                var obj = JObject.Load(reader);
                var property = obj.Properties().FirstOrDefault();
                var type = ((JValue)property.Name).ToObject<MatchType>(GetEnumSerializer());
                var value = (string)property.Value.SelectToken("value");
                return new MarkLogicMatchEntry { MatchType = type, Value = value };
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var match = (MarkLogicMatchEntry)value;
            if (match.MatchType == MatchType.Normal)
            {
                writer.WriteValue(match.Value);
            }
            else
            {
                var propertyName = (string)JToken.FromObject(match.MatchType, GetEnumSerializer());
                var obj = new JObject(new JProperty(propertyName, new JObject(new JProperty("value", match.Value))));
                obj.WriteTo(writer);
            }
        }
    }
