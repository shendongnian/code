    class CustomDataTableConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DataTable));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DataTable dt = (DataTable)value;
            JObject metaDataObj = new JObject();
            foreach (DataColumn col in dt.Columns)
            {
                metaDataObj.Add(col.ColumnName, col.DataType.AssemblyQualifiedName);
            }
            JArray rowsArray = new JArray();
            rowsArray.Add(metaDataObj);
            foreach (DataRow row in dt.Rows)
            {
                JObject rowDataObj = new JObject();
                foreach (DataColumn col in dt.Columns)
                {
                    rowDataObj.Add(col.ColumnName, JToken.FromObject(row[col]));
                }
                rowsArray.Add(rowDataObj);
            }
            rowsArray.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray rowsArray = JArray.Load(reader);
            JObject metaDataObj = (JObject)rowsArray.First();
            DataTable dt = new DataTable();
            foreach (JProperty prop in metaDataObj.Properties())
            {
                dt.Columns.Add(prop.Name, Type.GetType((string)prop.Value, throwOnError: true));
            }
            foreach (JObject rowDataObj in rowsArray.Skip(1))
            {
                DataRow row = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    row[col] = rowDataObj[col.ColumnName].ToObject(col.DataType);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
