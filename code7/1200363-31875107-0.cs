    public class RemoveHeaders: IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request,
            IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }
    
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
    
            var httpCtx = HttpContext.Current;
            if (httpCtx != null)
            {
                httpCtx.Response.Headers.Remove(HttpResponseHeader.Server.ToString());
            }
        }
    }
