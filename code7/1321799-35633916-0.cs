    public static void WriteXml(IEnumerable<string> lotsOfStrings, TextWriter output)
    {
        var stringsElement = new XStreamingElement("Strings",
            lotsOfStrings.Select(s => new XElement("Line", s)));
        var rootElement = new XStreamingElement("Root", stringsElement);
        //No XML is generated yet
        rootElement.Save(output); //Whole XML is generated and saved to output
    }
