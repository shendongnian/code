    private static void FillNames(XElement container, List<string> result)
    {
        XElement[] listNodes = container.Elements("ListNode").ToArray();
        if (!listNodes.Any())
            return;
        foreach (XElement listNode in listNodes)
        {
            XElement nameElement = listNode.Element("Name");
            if (nameElement == null)
                continue;
    
            XElement childrenElement = listNode.Element("Children");
            if (childrenElement == null)
                continue;
    
            if (!childrenElement.HasElements)
                result.Add(nameElement.Value);
            else
                FillNames(childrenElement, result);
        }
    }
    static void Main(string[] args)
    {
        var result = new List<string>();
    
        string xml = Resources.Xml; // TODO: put your xml here
    
        XDocument doc = XDocument.Parse(xml);
        if (doc.Root == null)
            return;
    
        XElement[] projects = doc.Root.Elements("ProjectList").ToArray();
    
        foreach (XElement project in projects)
            FillNames(project, result);
    }
