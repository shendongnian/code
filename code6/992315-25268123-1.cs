    If you don't want to use Datacontract  , i think you have to implement JsonConverter with some the methodes that you need.
    
        namespace JsonOutil
        {
            public class TestConverter<T> : JsonConverter
            {
                public override bool CanConvert(System.Type objectType)
                {
                    return objectType == typeof(yourClasse);
                }
        
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    object retVal = new Object();
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        T instance = (T)serializer.Deserialize(reader, typeof(T));
                        retVal = new List<T>() { instance };
                    }
                    else if (reader.TokenType == JsonToken.StartArray)
                    {
                        retVal = serializer.Deserialize(reader, objectType);
                    }
                    return retVal;
                }
        
         public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
                   {
                   
        
                   }
        
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    throw new System.NotImplementedException();
                }
                public string GetValueWhenReading(Dictionary<string, object> values, string key)
                {
                    return !values.ContainsKey(key) || values[key] == null
                        ? null
                        : values[key].ToString();
                }
            }
        }
