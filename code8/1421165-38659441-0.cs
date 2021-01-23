    public void ReadXml(XmlReader reader)
    {
        Name = reader.GetAttribute("Name");
        reader.Read();
    }
