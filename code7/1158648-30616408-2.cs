    public class TsonTextWriter : JsonTextWriter
    {
        TextWriter _writer;
        public TsonTextWriter(TextWriter textWriter)
            : base(textWriter)
        {
            if (textWriter == null)
                throw new ArgumentNullException("textWriter"); 
            QuoteName = false;
            _writer = textWriter;
        }
        public override void WriteStartObject()
        {
            SetWriteState(JsonToken.StartObject, null);
            _writer.Write('[');
        }
        protected override void WriteEnd(JsonToken token)
        {
            switch (token)
            {
                case JsonToken.EndObject:
                    _writer.Write(']');
                    break;
                default:
                    base.WriteEnd(token);
                    break;
            }
        }
        public override void WritePropertyName(string name)
        {
            WritePropertyName(name, true);
        }
        public override void WritePropertyName(string name, bool escape)
        {
            SetWriteState(JsonToken.PropertyName, name);
            var escaped = name;
            if (escape)
            {
                escaped = JsonConvert.ToString(name, '"', StringEscapeHandling);
                escaped = escaped.Substring(1, escaped.Length - 2);
            }
            // Maybe also escape the space character if it appears in a name?
            _writer.Write(escaped.Replace("=", @"\u003d"));// Replace "=" with unicode escape sequence.
            _writer.Write('=');
        }
        /// <summary>
        /// Writes the JSON value delimiter.  (Remove this override if you want to retain the comma separator.)
        /// </summary>
        protected override void WriteValueDelimiter()
        {
            _writer.Write(' ');
        }
        /// <summary>
        /// Writes an indent space.
        /// </summary>
        protected override void WriteIndentSpace()
        {
            // Do nothing.
        }
    }
