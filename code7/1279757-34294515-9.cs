    if (string.IsNullOrWhiteSpace(xmlString)) throw new ArgumentException("The provided string value is null or empty.");
    
    using (var stringReader = new StringReader(xmlString))
    {
        var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
        
        using (var xmlReader = XmlReader.Create(stringReader, settings))
        {
            if (!xmlReader.Read()) throw new ArgumentException(
                "The provided XML string does not contain enough data to be valid XML (see https://msdn.microsoft.com/en-us/library/system.xml.xmlreader.read)");
            var result = xmlReader.GetAttribute("encoding");
            return result;
        }
    }
