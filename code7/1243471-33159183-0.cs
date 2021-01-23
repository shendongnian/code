    public void ReadXml(XmlReader reader)
    {
        Values = XElement.Parse(reader.ReadOuterXml())
            .Elements()
            .ToDictionary(k => k.Name.ToString(), v => double.Parse(v.Value));
    }
