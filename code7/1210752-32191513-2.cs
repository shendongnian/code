    private ChannelFactory<IService> SetChannelFactory(int configInput)
                {
                    var identity = EndpointIdentity.CreateDnsIdentity(Configuration.EndpointConnections[configInput].Identity);
                    var myBinding = new WSHttpBinding(Configuration.EndpointConnections[configInput].Binding);
                    var myuri = new Uri(Configuration.EndpointConnections[configInput].Endpoint);
                    var myEndpoint = new EndpointAddress(myuri, identity);
                    return new ChannelFactory<IService>(myBinding, myEndpoint);
                }
