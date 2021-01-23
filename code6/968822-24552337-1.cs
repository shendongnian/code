        public class Entity
        {
            public DateTime? Date { get; set; }
        }
    
        public class DateTimeConverter : DateTimeConverterBase
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                DateTime val;
                if (reader.Value != null && DateTime.TryParse(reader.Value.ToString(), out val))
                {
                    return val;
                }
    
                return null;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value).ToString("MM/dd/yyyy"));
            }
        }
