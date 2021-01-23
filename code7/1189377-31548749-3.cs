    public class JavaArrayConverter : JsonConverter
    {
        Type _Type = null;
        public override bool CanConvert(Type objectType)
        {
            if(objectType.IsGenericType)
            {
                _Type = typeof(List<>).MakeGenericType(objectType.GetGenericArguments()[0]);
                return objectType == _Type;
            }
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jArray = JArray.Load(reader);
            
            //Remove the converter before *Deserialize* and than add it again
            //to avoid infinite recursion    
            var c = serializer.Converters.First();
            serializer.Converters.Clear();
            var obj = serializer.Deserialize(new JsonTextReader(new StringReader(jArray[1].ToString())), _Type);
            serializer.Converters.Add(c);
            return obj;
                
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
