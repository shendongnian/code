    CustomBinding binding = new CustomBinding();
    binding.Elements.Add( new HttpTransportBindingElement());
    binding.Elements.Add(new BinaryMessageEncodingBindingElement());
    var ep = new EndpointAddress("http://localhost:57222/LogMateReceiver.svc/binary");
    var factory = new ChannelFactory<MisWcfWsLogMate.ILogMateReceiver>(binding, ep);
    var channel = factory.CreateChannel();
    channel.MyMethod();
