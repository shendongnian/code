    public class EncodingValidatingStringConverter : JsonConverter
    {
        readonly Encoding encoding;
        public EncodingValidatingStringConverter()
            : this(Encoding.GetEncoding(Encoding.UTF8.CodePage, new EncoderReplacementFallback("?"), new DecoderExceptionFallback()))
        {
        }
        public EncodingValidatingStringConverter(Encoding encoding)
        {
            if (encoding == null)
                throw new ArgumentNullException();
            this.encoding = encoding;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override bool CanRead { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var s = (string)value;
            var bytes = encoding.GetBytes(s);
            var sFixed = encoding.GetString(bytes);
            writer.WriteValue(sFixed);
        }
    }
