    public class CustomInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel,
        InstanceContext instanceContext)
        {
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            reply = ChangeResponse(reply);
        }
        private Message ChangeResponse(Message oldMessage)
        {
           // change message
        }
    }
