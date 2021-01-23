    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
    {
    	Console.WriteLine("====SimpleMessageInspector+BeforeSendRequest is called=====");
      
    	//modify the request send from client(only customize message body)
    	request = TransformMessage2(request);
    
    	return null;
    }
    
    //only read and modify the Message Body part
    private Message TransformMessage2(Message oldMessage)
    {
    	Message newMessage = null;
    
    	//load the old message into XML
    	MessageBuffer msgbuf = oldMessage.CreateBufferedCopy(int.MaxValue);
    
    	Message tmpMessage = msgbuf.CreateMessage();
    	XmlDictionaryReader xdr = tmpMessage.GetReaderAtBodyContents();
    
    	XmlDocument xdoc = new XmlDocument();
    	xdoc.Load(xdr);
    	xdr.Close();
       
    	//transform the xmldocument
    	XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
    	nsmgr.AddNamespace("a", "urn:test:datacontracts");
    
    	XmlNode node = xdoc.SelectSingleNode("//a:StringValue", nsmgr);
    	if(node!= null) node.InnerText = "[Modified in SimpleMessageInspector]" + node.InnerText;
    
    	MemoryStream ms = new MemoryStream();
    	XmlWriter xw = XmlWriter.Create(ms);
    	xdoc.Save(xw);
    	xw.Flush();
    	xw.Close();
    
    	ms.Position = 0;
    	XmlReader xr = XmlReader.Create(ms);
       
    	//create new message from modified XML document
    	newMessage = Message.CreateMessage(oldMessage.Version, null,xr );
    	newMessage.Headers.CopyHeadersFrom(oldMessage);
    	newMessage.Properties.CopyProperties(oldMessage.Properties);
    
    	return newMessage;
    }
