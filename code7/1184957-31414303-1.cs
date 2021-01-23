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
                {
                    var c = serializer.Converters.First();
                    serializer.Converters.Clear(); //to avoid infinite recursion
                    var dict =  serializer.Deserialize<Dictionary<T1, T2>>(reader);
                    serializer.Converters.Add(c);
                    return dict;
                }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
