    static class ClientBaseExtensions
    {
        private const  HDR_TOKEN = "Token";
                               // insert this here
        public static void Initialize<T>(this ClientBase<T> client, string url, string pToken, string pDeviceId) where T : class
        {
            client.Endpoint.Address = new EndpointAddress(url);
            httpRequestProperty.Headers.Item(HDR_TOKEN) = pToken;
            OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = httpRequestProperty;
        }
    }
