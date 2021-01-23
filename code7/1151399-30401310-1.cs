    public class InterfaceLabelConverter : JsonConverter
    {
        private Guid? Convert(Guid? guid)
        {
            if (guid != null)
            {
                var bytes = guid.Value.ToByteArray();
                bytes[0] = unchecked((byte)~bytes[0]); // For example
                guid = new Guid(bytes);
            }
            return guid;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new InvalidOperationException(); // This converter should only be applied directly to a property.
        }
        public override bool CanRead { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var path = writer.Path;
            var propertyName = path.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Last(); // Throw an exception if not found.
            if (propertyName.StartsWith("[") && propertyName.EndsWith("]"))
                throw new InvalidOperationException(); // Trying to use this converter for an array element.
            var guid = (Guid?)value;
            writer.WriteValue(guid);
            if (guid != null)
            {
                // Note -- actually the converter isn't called for null values, see
                // https://stackoverflow.com/questions/8833961/serializing-null-in-json-net
                var nextGuid = Convert(guid);
                var nextName = "Old" + propertyName;
                writer.WritePropertyName(nextName);
                writer.WriteValue(nextGuid);
            }
        }
    }
