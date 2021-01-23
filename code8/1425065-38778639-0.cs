    class ObjectConverter : JsonConverter
    {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(Example);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      Example e = (Example)value;
      writer.WriteStartObject();
      writer.WritePropertyName("TypedProperty");
      writer.WriteValue(e.TypedProperty);
      writer.WritePropertyName("UntypedProperty");
      writer.WriteStartObject();
      writer.WritePropertyName("$type");
      writer.WriteValue(e.UntypedProperty.GetType().FullName);
      writer.WritePropertyName("$value");
      writer.WriteValue(e.UntypedProperty.ToString());
      writer.WriteEndObject();
      writer.WriteEndObject();
    }
    }
