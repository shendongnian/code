    public class EnumerationConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var enm = (Enumeration)value;
                writer.WriteValue(enm.Value);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value == null)
                {
                    return null;
                }
    
                int value;
    
                if (reader.ValueType == typeof(Int64))
                {
                    value = Convert.ToInt32(reader.Value);
                }
                else
                {
                    value = (int)reader.Value;
                }
    
                return Enumeration.FromValueOrDefault(objectType, value);
    
            }
    
            public override bool CanConvert(Type objectType)
            {
                if (objectType.BaseType == null) return false;
                return objectType.BaseType.Name == "Enumeration";
            }
        }
