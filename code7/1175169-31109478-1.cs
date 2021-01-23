    public void AppendExtractedRowsAsElements(XDocument doc)
    {
    	......
    	var process = doc.Root.Element("process");
    	process.Add(newElement);
    }
