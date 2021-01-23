    public class DataTableTo2dArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(DataTable).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var table = (DataTable)value;
            var array2d = table.AsEnumerable().Select(row => table.Columns.Cast<DataColumn>().Select(col => row[col]));
            serializer.Serialize(writer, new { data = array2d });
        }
    }
