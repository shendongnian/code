    Service1Client proxy = new Service1Client();
    proxy.Endpoint.Behaviors.Add(new MyBehavior());  
    public class MyBehavior : IEndpointBehavior
        {
        	public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        	{
        		MyInspector inspector = new MyInspector();
        		clientRuntime.MessageInspectors.Add(inspector);
        	}
    }
    public class MyInspector : IClientMessageInspector
    {
    	public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    	{
    		MemoryStream memStream = new MemoryStream();
    		XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateBinaryWriter(memStream);
    		//write xml elements like:
             xdw.WriteStartElement(“GetDataResponse”, “http://tempuri.org/”);
    		 
    		memStream.Position = 0;
    		XmlDictionaryReaderQuotas quotas = new XmlDictionaryReaderQuotas();
    		XmlDictionaryReader xdr = XmlDictionaryReader.CreateBinaryReader(memStream, quotas);
    
    		Message replacedMessage = Message.CreateMessage(reply.Version, null, xdr);
    		replacedMessage.Headers.CopyHeadersFrom(reply.Headers);
    		replacedMessage.Properties.CopyProperties(reply.Properties);
    		reply = replacedMessage;
    	}
    }
