    string url;
    
    using (var sr = new StringReader(callback))
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
