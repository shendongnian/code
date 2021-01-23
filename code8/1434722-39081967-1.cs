    xmlDocument = new XmlDocument();
    using (var stringWriter = new StringWriter(CultureInfo.InvariantCulture))
    {
        using (var xmlTextWriter = new XmlTextWriter(stringWriter))
        {
            xmlTextWriter.Formatting = Formatting.Intented;
            var xmlSerializer = new XmlSerializer(myObject.GetType());
            xmlSerializer.Serialize(xmlTextWriter, myObject);
            xmlDocument.PreserveWhitespace = true;
            xmlDocument.LoadXml(stringWriter.ToString());
        }
    }
