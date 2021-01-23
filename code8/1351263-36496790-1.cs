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
            var xml = "XML of Body goes here";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
            Message replacedMessage = Message.CreateMessage(reply.Version, null, xdr);
            replacedMessage.Headers.CopyHeadersFrom(reply.Headers);
            replacedMessage.Properties.CopyProperties(reply.Properties);
            reply = replacedMessage;
        }
    }
