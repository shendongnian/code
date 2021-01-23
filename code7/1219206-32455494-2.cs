    static void Main(string[] args)
    {
        XmlReaderSettings settings = new XmlReaderSettings()
        {
            IgnoreWhitespace = true
        };
        string xml = File.ReadAllText("XMLFile1.xml");
        using (XmlReader reader = XmlReader.Create(new StringReader(xml), settings))
        {
            var ser = new TimeTotalsResponseSerializer();
            ser.ReadXml(reader);
            var response = ser.Response;
        }
    }
