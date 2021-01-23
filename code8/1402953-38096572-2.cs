    static class HttpRequestMessageExtensions {
    
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";
    
        public static string GetClientIpString(this HttpRequestMessage request) {
            //Web-hosting
            if (request.Properties.ContainsKey(HttpContext)) {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null) {
                    return ctx.Request.UserHostAddress;
                }
            }
            //Self-hosting
            if (request.Properties.ContainsKey(RemoteEndpointMessage)) {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null) {
                    return remoteEndpoint.Address;
                }
            }
            //Owin-hosting
            if (request.Properties.ContainsKey(OwinContext)) {
                dynamic ctx = request.Properties[OwinContext];
                if (ctx != null) {
                    return ctx.Request.RemoteIpAddress;
                }
            }
            if (System.Web.HttpContext.Current != null) {
                return System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            // Always return all zeroes for any failure
            return "0.0.0.0";
        }
        public static IPAddress GetClientIpAddress(this HttpRequestMessage request) {
            var ipString = request.GetClientIpString();
            IPAddress ipAddress = new IPAddress(0);
            if (IPAddress.TryParse(ipString, out ipAddress)) {
                return ipAddress;
            }
            return ipAddress;
        }
    }
