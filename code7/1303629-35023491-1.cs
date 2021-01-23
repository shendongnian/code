    public class BinaryConverter<T> : JsonConverter where T : ISerializable
    {
        class BinaryData
        {
            public byte[] binaryData { get; set; }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var data = serializer.Deserialize<BinaryData>(reader);
            if (data == null || data.binaryData == null)
                return null;
            return BinaryFormatterHelper.FromByteArray<T>(data.binaryData);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = new BinaryData { binaryData = BinaryFormatterHelper.ToByteArray(value) };
            serializer.Serialize(writer, data);
        }
    }
    public static class BinaryFormatterHelper
    {
        public static byte [] ToByteArray<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return stream.ToArray();
            }
        }
        public static T FromByteArray<T>(byte[] data)
        {
            return FromByteArray<T>(data, null);
        }
        public static T FromByteArray<T>(byte[] data, BinaryFormatter formatter)
        {
            using (var stream = new MemoryStream(data))
            {
                formatter = (formatter ?? new BinaryFormatter());
                var obj = formatter.Deserialize(stream);
                if (obj is T)
                    return (T)obj;
                return default(T);
            }
        }
    }
