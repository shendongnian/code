    public static void IterateThroughAllNodes(this XmlDocument doc, Action<XmlNode> elementVisitor)
    {
        if (doc != null && elementVisitor != null)
        {
            foreach (XmlNode node in doc.ChildNodes)
            {
                DoIterateNode(node, elementVisitor);
            }
        }
    }
    
    public static void IterateThrough(this XmlNodeList nodes, Action<XmlNode> elementVisitor)
    {
        if (nodes != null && elementVisitor != null)
        {
            foreach (XmlNode node in nodes)
            {
                DoIterateNode(node, elementVisitor);
            }
        }
    }
    
    private static void DoIterateNode(XmlNode node, Action<XmlNode> elementVisitor)
    {
        elementVisitor(node);
        foreach (XmlNode childNode in node.ChildNodes)
        {
            DoIterateNode(childNode, elementVisitor);
        }
    }
