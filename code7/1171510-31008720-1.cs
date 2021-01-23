	void Main()
	{
		XDocument doc= XDocument.Load(@"d:\test2.xml");
		XmlNamespaceManager xnm = new XmlNamespaceManager(new NameTable()); 
		GetElement(doc, "//partners/partner/idAsign", xnm).Dump();
	}
	
	public IEnumerable<XElement> GetElement(XDocument doc, string xpath, IXmlNamespaceResolver res)
	{
		return doc.XPathSelectElements(xpath, res);
	}
