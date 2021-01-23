    var constsDocument = new List<XNode> {
               new XComment($" Consts section generated on {DateTime.Now} "),
               new XComment($" First group of constants. "),
               new XElement("example"),
               new XComment($" Refrigerant constants. "),
               new XElement("another")
    };
    // To avoid xml file starting with <?xml version="1.0" encoding="utf-8"?> use stringbuilder and StreamWriter.
    StringBuilder sb = new StringBuilder();
    XmlWriterSettings xws = new XmlWriterSettings
    {
        OmitXmlDeclaration = true,
        Indent = true,
        ConformanceLevel = ConformanceLevel.Fragment
    };
    using (XmlWriter xw = XmlWriter.Create(sb, xws))
    {
        foreach (var element in constsDocument)
        {
            element.WriteTo(xw);
        }
    }
    System.IO.StreamWriter file = new System.IO.StreamWriter(_outputPath);
    file.WriteLine(sb.ToString());
    file.Close();
