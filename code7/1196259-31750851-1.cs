        public class MyClass
        {
            [JsonConverter(typeof(NullToDefaultConverter<Guid>))]
            public Guid Property { get; set; }
        }
        public class NullToDefaultConverter<T> : JsonConverter where T : struct
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(T);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var token = JToken.Load(reader);
                if (token == null || token.Type == JTokenType.Null)
                    return default(T);
                return token.ToObject(objectType);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (EqualityComparer<T>.Default.Equals((T)value, default(T)))
                    writer.WriteNull();
                else
                    writer.WriteValue(value);
            }
        }
 
