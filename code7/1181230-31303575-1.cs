    class PreventStringEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = value.GetType();
            var undertype = Enum.GetUnderlyingType(type);
            var converted=Convert.ChangeType(value, undertype);
            writer.WriteValue(converted);
        }
    }
