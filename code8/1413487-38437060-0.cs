    public class TableRowConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TableRow);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var cells = serializer.Deserialize<Cell[]>(reader);
            return new TableRow { Cells = cells };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var row = (TableRow)value;
            serializer.Serialize(writer, row.Cells);
        }
    }
    public class JsonDerivedTypeConverter<TBase, TDerived> : JsonConverter where TDerived : TBase
    {
        public JsonDerivedTypeConverter()
        {
            if (typeof(TBase) == typeof(TDerived))
                throw new InvalidOperationException("TBase and TDerived cannot be identical");
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TBase);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TDerived>(reader);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
