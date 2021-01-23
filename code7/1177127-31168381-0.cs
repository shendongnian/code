    foreach (XNode node in root.Nodes())
    {
        if (node.NodeType == XmlNodeType.Element)
        {
            XElement elem = (XElement)node;
            content.Append(elem.Name.LocalName)
                .Append(": id=")
                .Append(elem.Attribute("id").Value)
                .Append(": value=")
                .Append(elem.Attribute("value").Value);
        }
        else if (node.NodeType == XmlNodeType.Text)
        {
            XText text = (XText)node;
            content.Append(" extra data= ")
                .Append(text.Value.Trim())
                .AppendLine();
        }
    }
