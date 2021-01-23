        public class CustomConverter : JsonConverter
        {
    
            public override bool CanConvert(System.Type objectType)
            {
                return true;// objectType.IsAssignableFrom(typeof(Encoding));
            }
    
            public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
            {
                return Encoding.GetEncoding(Convert.ToString(reader.Value));
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var t = (Test)value;
                var e = (Encoding)t.MyProperty;
                writer.WriteValue(e.BodyName);
                //serializer.Serialize(writer, e.BodyName);
            }
        }
