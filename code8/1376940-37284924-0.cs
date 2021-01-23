    public string ToXML()
    {
    	return new XDocument(
    				new XElement("NodeSurrounded"),
    					new XElement("A", this.Property)).ToString();
    }
    
    public void FromXML(string xml)
    {
    	var document = XDocument.Parse(xml);
    	this.Property = document.Root.Element("A").Element("Property").Value;
    }
