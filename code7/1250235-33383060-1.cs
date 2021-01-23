    public void Deserialize()
    {
    	TmsMsg msg = null;
    	var msgDict = new Dictionary<string, string>();
    
    	using (var stream = new FileStream("Type2.xml", FileMode.Open))
    	{
    		XmlSerializer ser = new XmlSerializer(typeof(TmsMsg));
    		msg = ser.Deserialize(stream) as TmsMsg;
    	}
    
    	// type 1 : message_string element has a xml text node
    	// type 2 : message_string element has a xml elements
    	foreach (var node in msg.Transaction.MessageString)
    	{
    		if (node.NodeType == XmlNodeType.Text)
    		{
    			msgDict.Add("message_string", node.Value);
    		}
    		else if (node.NodeType == XmlNodeType.Element)
    		{
    			msgDict.Add(node.Name, node.InnerText);
    		}
    	}
    }
