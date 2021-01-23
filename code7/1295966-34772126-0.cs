    public class MicrosecondEpochConverter : DateTimeConverterBase
    {
     public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    { return; }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      return new DateTime(Convert.ToInt64(reader.Value));
    }
