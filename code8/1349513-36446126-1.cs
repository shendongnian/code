    public  List<XmlNode> XMlNodeFind(XmlNodeList steps, string ID)
    {
    	var resultNodes = new List<XmlNode>();
    	foreach (XmlNode node in steps)
    	{
    		if (node.Attributes != null && node.Attributes["name"] != null &&node.Attributes["name"].Value.Equals(ID))
    		{
    			resultNodes.Add(node);
    		}
    		resultNodes.AddRange(XMlNodeFind(node.ChildNodes, ID));
    
    	}
    	return resultNodes;
    }
