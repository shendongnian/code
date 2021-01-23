    string url;
    
    using (var sr = new StringReader(xml))
    using (var reader = XmlReader.Create(sr))
    {
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "URL")
            {
                url = reader.ReadElementString();
                break;
            }
        }
    }
