    public class MessageInspector : 
        IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var r = request.ToString(); // this will return the SOAP string...
            return request;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            //throw new NotImplementedException();
        }
    }
