    public static class Config
    {
        static Config()
        {
            var doc = new XmlDocument();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Fully.Qualified.Name.Config.xml"))
            {
                if (stream == null)
                {
                    throw new EndOfStreamException("Failed to read Fully.Qualified.Name.Config.xml from the assembly's embedded resources.");
                }
                using (var reader = new StreamReader(stream))
                {
                    doc.LoadXml(reader.ReadToEnd());
                }
            }
            XmlElement aValue = null;
            XmlElement anotherValue = null;
            var config = doc["config"];
            if (config != null)
            {
                aValue = config["a-value"];
                anotherValue = config["another-value"];
            }
            if (aValue == null || anotheValue == null)
            {
                throw new XmlException("Failed to parse Config.xml XmlDocument.");
            }
            AValueProperty = aValue.InnerText;
            AnotherValueProperty = anotherValue.InnerText;
        }
    }
