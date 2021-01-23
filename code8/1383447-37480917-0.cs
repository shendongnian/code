	XDocument doc  = XDocument.Load(filename);
	var elements = doc.Root.Element("group").Elements().ToList();  // Copy the elements.
	
	doc.Root.Element("group").RemoveAll();		                   // Remove the elements from the document.
	doc.Root.Element("group").Add(elements.OrderBy(x=>int.Parse(x.Attribute("order").Value)));
    //Add them again after sorting.
