    foreach (var element in xmlDoc.SelectNodes("WorkItem/Children").OfType<XmlElement>())
    {
        var elements = element.SelectNodes("WorkItem[WorkItemType[text()='Product Backlog Item' or text()='Task']]");
        foreach(var child in elements.OfType<XmlElement>())
             Process(child);                
    }
    public void Process(XmlElement rootElement)
    {
        // Print some info about the work item
        // ...
        foreach (var element in rootElement.SelectNodes("Children").OfType<XmlElement>())
        {
            // I'm not sure whether it's exactly what you want but you can 
            // easily change this expression.
            var children = element.SelectNodes("WorkItem[WorkItemType[text()='Task']]");
            // continue the processing of children
            foreach (var child in children.OfType<XmlElement>())
                Process(child);
        }
    }
