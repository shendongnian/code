    public class DataReaderConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDataReader).IsAssignableFrom(objectType);
        }
        public override bool CanRead { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var reader = (IDataReader)value;
            writer.WriteStartArray();
            while (reader.Read())
            {
                writer.WriteStartObject();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    writer.WritePropertyName(reader.GetName(i));
                    if (reader.IsDBNull(i))
                        writer.WriteNull();
                    else
                        serializer.Serialize(writer, reader[i]);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
