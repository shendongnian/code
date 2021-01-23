    public class MyJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectToSerialize = new {}; //create the object you want to serialize here, based on your dynamic conditions
            new JsonSerializer().Serialize(writer, objectToSerialize); //serialize the object to the current writer
        }
    }
