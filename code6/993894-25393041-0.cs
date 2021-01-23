    public class CorsWebHttpDispatchOperationSelector : WebHttpDispatchOperationSelector
    {
    
        private WebHttpDispatchOperationSelector target;
        private ServiceEndpoint endpoint;
    
        OperationDescription optionOperation;
    
        public CorsWebHttpDispatchOperationSelector(ServiceEndpoint endpoint, WebHttpDispatchOperationSelector target)
        {
            this.target = target;
            this.endpoint = endpoint;
    
            foreach (var item in this.endpoint.Contract.Operations) {
                var webInvoke = item.Behaviors.OfType<WebInvokeAttribute>().FirstOrDefault();
                if (webInvoke != null && webInvoke.Method.Equals("options",StringComparison.OrdinalIgnoreCase) && webInvoke.UriTemplate == "*") {
                    optionOperation = item;
                    break;
                }
            }
        }
        #region IDispatchOperationSelector Members
    
        protected override string SelectOperation(ref Message message, out bool uriMatched)
        {
            var result = target.SelectOperation(ref message);
    
            var matched = message.Properties["UriMatched"] as bool?;
            message.Properties.Remove("UriMatched");
            message.Properties.Remove("HttpOperationName");
            uriMatched = matched.HasValue && matched.Value;
    
            var httpRequest = message.Properties["httpRequest"] as HttpRequestMessageProperty;
    
            var cond = string.IsNullOrEmpty(result) && 
                            httpRequest != null && 
                            httpRequest.Method.Equals("options",StringComparison.OrdinalIgnoreCase);
    
            if (cond && optionOperation != null) {
                result = optionOperation.Name;
                uriMatched = true;
            }
    
            return result;
        }
        #endregion
    }
    
    public class CorsWebHttpBehavior : WebHttpBehavior {
        protected override WebHttpDispatchOperationSelector GetOperationSelector(ServiceEndpoint endpoint)
        {
            return new CorsWebHttpDispatchOperationSelector(endpoint, base.GetOperationSelector(endpoint));
        }
    }
