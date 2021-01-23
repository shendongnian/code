    Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
    string typeName = typeof(Interface.IProductService).Name;
    ChannelFactory<Interface.IProductService> cf = new 
         ChannelFactory<Interface.IProductService>(typeName);
    Interface.IProductService tc = cf.CreateChannel();
    tc.GetProduct(1);
