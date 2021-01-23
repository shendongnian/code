    public static bool CopyNode(string fileName, string originalClassName, string newClassName, string nodeName, string ID)
	{
		XDocument doc = XDocument.Load(fileName);
			
		if(doc == null)
			throw new ArgumentNullException("doc");
		XElement originalClassElement = doc.Root.Descendants().FirstOrDefault(e => e.Name == "Class" && e.Attribute("Name").Value == originalClassName);
		if (originalClassElement == null)
			return false;
    
		XElement elementToCopy = originalClassElement.Elements().FirstOrDefault(e => e.Name == nodeName && e.Attribute("Id").Value == ID);
		if (elementToCopy == null)
			return false;
		XElement newClassElement = doc.Root.Descendants().FirstOrDefault(e => e.Name == "Class" && e.Attribute("Name").Value == newClassName);
		if (newClassElement == null)
			return false;
		newClassElement.Add(elementToCopy);
		doc.Save(fileName);
		return true;
	}
