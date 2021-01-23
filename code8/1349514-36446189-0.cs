    string ID = "9";
    public void XMlNodeFind(XmlNodeList steps, string ID)
    {
        var resultNodes = new List<XmlNode>();
        foreach (XmlNode node in steps)
        {
            if (node.Attributes["name"].Value.Equals(ID))
            {
                resultNodes.Add(node);
            }
        }
    }
