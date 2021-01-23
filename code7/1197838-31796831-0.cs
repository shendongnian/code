    public class WCFMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //in this sample I use predefined Guid to distinct specific client...
            Guid clientId = new Guid("5DBD6E89-81F2-4786-BC93-2758A8368A5D");
            MessageHeader<Guid> header = new MessageHeader<Guid>((Guid)clientId);
            MessageHeader untyped = header.GetUntypedHeader("Identity", "My Custom Namespace");
            request.Headers.Add(untyped);
            return null;
        }
    }
