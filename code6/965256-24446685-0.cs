    public class WcfMessageInterceptor : IDispatchMessageInspector, IClientMessageInspector
    {
		[ThreadStatic]
        private static string service1GUID;
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            service1GUID = request.Headers.GetHeader("service1-guid-header", "s");
		}
		
		public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
			var serviceName="";
			if (channel != null && channel.RemoteAddress != null)
            {
                var tmp = request.Headers.Action.Substring(0, request.Headers.Action.LastIndexOf('/'));
                serviceName = tmp.Substring(tmp.LastIndexOf('/') + 1);
            }
            var methodName = request.Headers != null
                                    ? request.Headers.Action.Substring(request.Headers.Action.LastIndexOf('/') + 1)
                                    : "Action";
			//check if the called service is the right one
			if(serviceName=="Service2"){
                var typedHeader = new MessageHeader(service1GUID);
				var untypedHeader = typedHeader.GetUntypedHeader("service1-guid-in-service2-header", "s");
				request.Headers.Add(untypedHeader);
			}
		}
	}
