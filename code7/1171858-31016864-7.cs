    foreach (var element in doc.Descendants().Where(o => o.Attribute("Header") != null))
    {
    	//delete all existing content
    	element.DescendantNodes().Remove();
    	//add new content element named "ParentElementName.HeaderTemplate"
    	element.Add(new XElement(element.Name.LocalName + ".HeaderTemplate", template));
    }
    //print the modified XDocument (or save to file instead)
    Console.WriteLine(doc.ToString());
