    using (var reader = XmlReader.Create(basePath, settings))
    {
        var elements = new Stack<string>();
    
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    if(!reader.IsEmptyElement)
                        elements.Push(reader.LocalName);
                    break;
                case XmlNodeType.EndElement:
                    elements.Pop();
                    break;
                case XmlNodeType.Text:
                    path = string.Join("/", elements.Reverse());
                    break;
            }
        }
    }
