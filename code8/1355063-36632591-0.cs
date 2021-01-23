    var binding = new CustomBinding();
    var be1 = new BinaryMessageEncodingBindingElement();
    be1.CompressionFormat = CompressionFormat.GZip;
    binding.Elements.Add(be1);
    var be2 = new TcpTransportBindingElement();
    be2.MaxBufferSize = 100000000;
    be2.MaxReceivedMessageSize = 100000000;
    binding.Elements.Add(be2);
    binding = new CustomBinding(binding);
