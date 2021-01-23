    public class SimpleMessageInspector : IClientMessageInspector, IDispatchMessageInspector {
        public void AfterReceiveReply(ref Message reply, object correlationState) {
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel) {
            UsernameToken authentication = new UsernameToken(remoteServiceUsername, remoteServicePassword, PasswordOption.SendPlainText); //Plain text is server requirement, we cannot do anything
            
            var webUserHeader = MessageHeader.CreateHeader("Security", 
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", authentication.GetXml(new XmlDocument()));
	        request.Headers.Add(webUserHeader);
 
            return null;
        }
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext) {
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState) {
        }
    }
