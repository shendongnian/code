    public class CustomConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var o = (MyModel)value;
            writer.WriteStartObject();
            writer.WritePropertyName("a");
            writer.WriteValue(o.a);
            writer.WritePropertyName("b");
            writer.WriteValue(o.b[0]);
            writer.WriteEndObject();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyModel);
        }
        //...
    }
}
