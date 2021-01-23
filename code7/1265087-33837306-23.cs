    public class DataReaderArrayConverter : JsonConverter
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
        static string[] GetFieldNames(IDataReader reader)
        {
            var fieldNames = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
                fieldNames[i] = reader.GetName(i);
            return fieldNames;
        }
        static void ValidateFieldNames(IDataReader reader, string[] fieldNames)
        {
            if (reader.FieldCount != fieldNames.Length)
                throw new InvalidOperationException("Unequal record lengths");
            for (int i = 0; i < reader.FieldCount; i++)
                if (fieldNames[i] != reader.GetName(i))
                    throw new InvalidOperationException(string.Format("Field names at index {0} differ: \"{1}\" vs \"{2}\"", i, fieldNames[i], reader.GetName(i)));
        }
        const string columnsName = "columns";
        const string rowsName = "rows";
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var reader = (IDataReader)value;
            writer.WriteStartObject();
            string[] fieldNames = null;
            while (reader.Read())
            {
                if (fieldNames == null)
                {
                    writer.WritePropertyName(columnsName);
                    fieldNames = GetFieldNames(reader);
                    serializer.Serialize(writer, fieldNames);
                    writer.WritePropertyName(rowsName);
                    writer.WriteStartArray();
                }
                else
                {
                    ValidateFieldNames(reader, fieldNames);
                }
                writer.WriteStartArray();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.IsDBNull(i))
                        writer.WriteNull();
                    else
                        serializer.Serialize(writer, reader[i]);
                }
                writer.WriteEndArray();
            }
            if (fieldNames != null)
            {
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
