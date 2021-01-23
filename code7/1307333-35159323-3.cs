    // Initialize the channel which will be created with the server.
    // SessionChannel channel = SessionChannel.Create(
    //    configuration,
    //    endpointDescription,
    //    endpointConfiguration,
    //    bindingFactory,
    //    clientCertificate,
    //    null);
    ITransportChannel channel = WcfChannelBase.CreateUaBinaryChannel(
        configuration,
        endpointDescription,
       endpointConfiguration,
       clientCertificate,
       configuration.CreateMessageContext());
    // Wrap the channel with the session object.
    // This call will fail if the server does not trust the client certificate.
    // m_Session = new Session(channel, configuration, endpoint);
     m_Session = new Session(channel, configuration, endpoint, clientCertificate);
