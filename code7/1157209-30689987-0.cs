            System.ServiceModel.EndpointAddress endpointAddress = new System.ServiceModel.EndpointAddress("net.tcp://YourIpAddress:4502/CTMSEngine/net");
            System.ServiceModel.Channels.CustomBinding customBinding = new System.ServiceModel.Channels.CustomBinding();
            System.ServiceModel.Channels.BinaryMessageEncodingBindingElement BMEelement = new System.ServiceModel.Channels.BinaryMessageEncodingBindingElement();
            System.ServiceModel.Channels.TcpTransportBindingElement TcpTelement = new System.ServiceModel.Channels.TcpTransportBindingElement();
            customBinding.Elements.Add(BMEelement);
            customBinding.Elements.Add(TcpTelement);
            TcpTelement.MaxReceivedMessageSize = 2147483647;
            TcpTelement.MaxBufferSize = 2147483647;
            proxy = new ServerConnectionClient(customBinding, endpointAddress);
