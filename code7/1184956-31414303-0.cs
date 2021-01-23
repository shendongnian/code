    public class KVListToDictConverter<T1,T2> : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Dictionary<T1, T2>) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
                return serializer.Deserialize<List<KeyValuePair<T1, T2>>>(reader).ToDictionary(x => x.Key, x => x.Value);
            else
                return serializer.Deserialize<Dictionary<T1, T2>>(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
