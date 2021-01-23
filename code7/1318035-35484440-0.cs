    public class OnlyStringEnumConverter : StringEnumConverter
    {
        public OnlyStringEnumConverter()
        {
            AllowIntegerValues = false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!AllowIntegerValues && reader.ValueType == typeof(string) && reader.Value != null)
            {
                int newValue;
                if (Int32.TryParse(reader.Value.ToString(), out newValue))
                    throw new ArgumentException("Integer value  is not allowed:" + reader.Value);
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
