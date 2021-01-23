    static void Main(string[] args)
    {
         var response = GetResponse(File.ReadAllText("XMLFile1.xml"));
    }
    static TimeTotalsResponse GetResponse(string xml)
    {
        using (StringReader reader = new StringReader(xml))
        {
            var ser = new XmlSerializer(typeof(TimeTotal));
            return new TimeTotalsResponse() { TimeTotal = (TimeTotal)ser.Deserialize(reader) };
        }
    }
