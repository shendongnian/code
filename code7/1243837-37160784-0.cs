    OperationContext context = OperationContext.Current;
                MessageProperties properties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string address = string.Empty;
                //http://www.simosh.com/article/ddbggghj-get-client-ip-address-using-wcf-4-5-remoteendpointmessageproperty-in-load-balanc.html
                if (properties.Keys.Contains(HttpRequestMessageProperty.Name))
                {
                    HttpRequestMessageProperty endpointLoadBalancer = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    if (endpointLoadBalancer != null && endpointLoadBalancer.Headers["X-Forwarded-For"] != null)
                        address = endpointLoadBalancer.Headers["X-Forwarded-For"];
                }
                if (string.IsNullOrEmpty(address))
                {
                    address = endpoint.Address;
                }
