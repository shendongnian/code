    public class SpecialDateTimeConverter : DateTimeConverterBase
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                 writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy hh:mm:ss"));
            }
        }
    
        string convertedDateTime = JsonConvert.SerializeObject(DateTime.Now, Formatting.Indented, new SpecialDateTimeConverter());
