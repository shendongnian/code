    public class MyStringEnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.Equals(InitialScanLevel.SystemDefault)) value = null;
            base.WriteJson(writer, value, serializer);
        }
    }
    [JsonConverter(typeof(MyStringEnumConverter))]
    public enum InitialScanLevel
    {
     .....
    }
