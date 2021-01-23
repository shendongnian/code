    public class CustomDateTimeWriter : XmlTextWriter
    {
        public CustomDateTimeWriter(TextWriter writer) : base(writer) { }
        public CustomDateTimeWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public CustomDateTimeWriter(string filename, Encoding encoding) : base(filename, encoding) { }
        public override void WriteRaw(string data)
        {
            DateTime dt;
            if (DateTime.TryParse(data, out dt))
                base.WriteRaw(dt.ToString("u", new CultureInfo("en-US")));
            else
                base.WriteRaw(data);
        }
    }
    public class CustomDateTimeReader : XmlTextReader
    {
        public CustomDateTimeReader(TextReader input) : base(input) { }
        // define other required constructors
        public override string ReadElementString()
        {
            string data = base.ReadElementString();
            DateTime dt;
            if (DateTime.TryParse(data, null, DateTimeStyles.AdjustToUniversal, out dt))
                return dt.ToString("o");
            else
                return data;
        }
    }
