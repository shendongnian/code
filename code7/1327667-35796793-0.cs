    private bool ReadNameAndValue(XmlNode parent, out string name, out string value)
    {
    	name = "";
    	value = "";
    
    	var node = parent.SelectSingleNode("./string");
    	if (node == null)
    	{
    		return false;
    	}
    
    	try
    	{
    		name = parent.SelectSingleNode("./string/@name").InnerText;
    		value = parent.SelectSingleNode("./string/@value").InnerText;
    	}
    	catch(Exception)
    	{
    	}
    
    	return true;
    }
    
    public void ParseDoc(string fileName = @"c:\temp\soexample.xml")
    {
    	XmlDocument doc = new XmlDocument();
    	doc.Load(fileName);
    
    	var elements = doc.SelectNodes("//imgdir");
    
    	foreach (XmlNode node in elements)
    	{
    		string name;
    		string value;
    		if (ReadNameAndValue(node, out name, out value))
    		{
    			string id = node.SelectSingleNode("./@name").InnerText;
    			Console.WriteLine("Id: " + id + ", Name: " + name + ", Value: " + value);
    
    			//do whatever you want with the id, name and value
    		}
    	}
    }
