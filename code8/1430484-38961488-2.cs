    static IProblemSolverChannel CreateChannel(Binding binding, Uri uri, TransportClientEndpointBehavior transportClientEndpointBehavior)
    {
        ChannelFactory<IProblemSolverChannel> cf;
        if (binding is WebHttpBinding || binding is WebHttpRelayBinding)
        {
            cf = new WebChannelFactory<IProblemSolverChannel>(binding, uri);
        }
        else
        {
            cf = new ChannelFactory<IProblemSolverChannel>(binding, new EndpointAddress(uri));
        }
        cf.Endpoint.Behaviors.Add(transportClientEndpointBehavior);
        return cf.CreateChannel();
    }
