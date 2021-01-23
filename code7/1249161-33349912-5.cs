    public class IncomingMessageLogger : IDispatchMessageInspector
    {
        const string MessageLogFolder = @"c:\temp\";
        static int messageLogFileIndex = 0;
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            string messageFileName = string.Format("{0}Log{1:000}_Incoming.txt", MessageLogFolder, Interlocked.Increment(ref messageLogFileIndex));
            Uri requestUri = request.Headers.To;
            HttpRequestMessageProperty httpReq = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            // Decode the message from request and do whatever you want to do.
            string jsonMessage = this.MessageToString(ref request);
            return requestUri;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
