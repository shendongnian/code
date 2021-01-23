    public class JsonNameTable
        : System.Xml.NameTable
    {
    }
    public class JsonNameTableConverter
        : JsonConverter
    {
        private JsonNameTable _nameTable;
        public JsonNameTableConverter(JsonNameTable nameTable)
        {
            _nameTable = nameTable;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var s = reader.TokenType == JsonToken.String ? (string)reader.Value : (string)Newtonsoft.Json.Linq.JToken.Load(reader); // Check is in case the value is a non-string literal such as an integer.
            if (s != null)
            {
                s = _nameTable.Add(s);
            }
            return s;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
