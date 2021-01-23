    return delegate (StatelessServiceContext context)
            {
                string host = HostFromConfig(context);
                if (string.IsNullOrWhiteSpace(host))
                {
                    host = context.NodeContext.IPAddressOrFQDN;
                }
                var endpointConfig = context.CodePackageActivationContext.GetEndpoint("ServiceEndpoint");
                int port = endpointConfig.Port;
                string scheme = endpointConfig.Protocol.ToString();
                //http://mycluster.region.cloudapp.azure.com or http://localhost
                string uri = string.Format(CultureInfo.InvariantCulture, "{0}://{1}:{2}", scheme, host, port);
                var listener = new WcfCommunicationListener<IHello>(
                    wcfServiceObject: this,
                    serviceContext: context,
                    listenerBinding: CreateDefaultHttpBinding(),
                    address: new EndpointAddress(uri)
                );
                return listener;
            };
