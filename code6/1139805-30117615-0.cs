    var channelFactory = new WSTrustChannelFactory(binging, endpoint)
    {
           TrustVersion = TrustVersion.WSTrust13
    };
    channelFactory.WSTrustRequestSerializer = CustomRequestSerializer;
