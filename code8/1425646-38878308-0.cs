    [JsonConverter(typeof(OracleDataTableJsonResponseConverter))]
    public sealed class OracleDataTableJsonResponse
    {
        public string ConnectionString { get; private set; }
        public string QueryString { get; private set; }
        public OracleParameter[] Parameters { get; private set; }
        public OracleDataTableJsonResponse(string connStr, string strQuery, OracleParameter[] prms)
        {
            this.ConnectionString = connStr;
            this.QueryString = strQuery;
            this.Parameters = prms;
        }
    }
    class OracleDataTableJsonResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OracleDataTableJsonResponse);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("OracleDataTableJsonResponse is only for writing JSON.  To read, deserialize into a DataTable");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var response = (OracleDataTableJsonResponse)value;
            using (var dbconn = new OracleConnection(response.ConnectionString))
            {
                using (var selectCommand = new OracleCommand(response.QueryString, dbconn))
                {
                    if (response.Parameters != null)
                        selectCommand.Parameters.AddRange(response.Parameters);
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        writer.WriteDataTable(reader, serializer);
                    }
                }
            }
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
    }
