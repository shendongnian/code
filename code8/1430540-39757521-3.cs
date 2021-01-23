    namespace DataReaderDebugUtilities
    {
        public static class DataReaderExtensions
        {
            public static object[] CurrentValues(this IDataReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException();
                var objs = new object[reader.FieldCount];
                reader.GetValues(objs);
                return objs;
            }
            public static KeyValuePair<string, object> [] CurrentNamesAndValues(this IDataReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException();
                var query = Enumerable.Range(0, reader.FieldCount).Select(i => new KeyValuePair<string, object>(reader.GetName(i), reader.GetValue(i)));
                return query.ToArray();
            }
            public static string ToStringAsDataTable(this IDataReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException();
                var sb = new StringBuilder();
                using (var textWriter = new StringWriter(sb))
                using (var jsonWriter = new JsonTextWriter(textWriter) { Formatting = Formatting.Indented })
                {
                    var serializer = JsonSerializer.CreateDefault();
                    jsonWriter.WriteDataTable(reader, serializer);
                }
                return sb.ToString();
            }
            public static string ToStringAsDataSet(this IDataReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException();
                var sb = new StringBuilder();
                using (var textWriter = new StringWriter(sb))
                using (var jsonWriter = new JsonTextWriter(textWriter) { Formatting = Formatting.Indented })
                {
                    var serializer = JsonSerializer.CreateDefault();
                    jsonWriter.WriteDataSet(reader, serializer);
                }
                return sb.ToString();
            }
        }
        public static class JsonExtensions
        {
            public static void WriteDataTable(this JsonWriter writer, IDataReader reader, JsonSerializer serializer)
            {
                if (writer == null || reader == null || serializer == null)
                    throw new ArgumentNullException();
                writer.WriteStartArray();
                while (reader.Read())
                {
                    writer.WriteStartObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        writer.WritePropertyName(reader.GetName(i));
                        serializer.Serialize(writer, reader[i]);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
    
            public static void WriteDataSet(this JsonWriter writer, IDataReader reader, JsonSerializer serializer)
            {
                if (writer == null || reader == null || serializer == null)
                    throw new ArgumentNullException();
                writer.WriteStartObject();
    
                do
                {
                    var tableName = string.Empty;
                    var schemaTable = reader.GetSchemaTable();
                    if (schemaTable != null)
                        tableName = schemaTable.Rows.Cast<DataRow>()
                            .Select(r => r[schemaTable.Columns[System.Data.Common.SchemaTableColumn.BaseTableName]].ToString())
                            .FirstOrDefault();
                    writer.WritePropertyName(tableName ?? string.Empty);
                    writer.WriteDataTable(reader, serializer);
                }
                while (reader.NextResult());
    
                writer.WriteEndObject();
            }
        }
    }
