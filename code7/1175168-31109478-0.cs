    public void AppendExtractedRowsAsElements(XDocument doc)
    {
    	......
    	var process = doc.Root.Element("process");
    	doc.Root.Add(newElement);
    }
