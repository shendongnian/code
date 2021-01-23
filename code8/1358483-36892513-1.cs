    public class LoggingMessageInspector : IDispatchMessageInspector
    {
        private static readonly Logger CurrentClassLogger = LogManager.GetCurrentClassLogger();
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return request.Headers.To;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var requestUri = (Uri)correlationState;
            var currentContext = WebOperationContext.Current;
            if (currentContext == null)
            {
                CurrentClassLogger.Log(LogLevel.Error, "Cannot log reply to [{0}]: WebOperationContext is null", requestUri);
                return;
            }
            try
            {
                var httpRequest = currentContext.IncomingRequest;
                string host = httpRequest.Headers[HttpRequestHeader.Host];
                string method = httpRequest.Method;
                string userAgent = httpRequest.UserAgent;
                var statusCode = currentContext.OutgoingResponse.StatusCode;
                CurrentClassLogger.Log(LogLevel.Info, "[Host {0}] [{1} {2} {3} {4}] [{5}]", host, method, requestUri, (int) statusCode, statusCode,  userAgent);
            }
            catch (Exception ex)
            {
                CurrentClassLogger.Error("Cannot log reply to [{0}] : {1}", requestUri, ex);
            }
        }
    }
