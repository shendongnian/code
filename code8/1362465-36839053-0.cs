     public class WcfMessageInterceptor : IClientMessageInspector
        {
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
                request = buffer.CreateMessage();
                LogService.Log("Request:" + Environment.NewLine + buffer.CreateMessage());
                return null;
            }
    
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                reply = buffer.CreateMessage();
                LogService.Log("Reply:" + Environment.NewLine + buffer.CreateMessage());
            }
        }
