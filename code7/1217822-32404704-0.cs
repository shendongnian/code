    public class BodMessageInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                return instanceContext;
            }
    
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                // DO your stuff here and validate your reply Message
            }
        }
