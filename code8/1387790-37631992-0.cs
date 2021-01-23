    // binding
    var binding = new WSHttpBinding();
    // using System.ServiceModel
    var channelFactory = new ChannelFactory<InfoWcfWS.IInfo>(binding);
    // using System.ServiceModel.Description
    var endpointClientbehavior = new ClientCredentials();
    endpointClientbehavior.ClientCertificate
        .SetCertificate(
        "This is my TEST Cert", 
        StoreLocation.LocalMachine, 
        StoreName.My);
    // add the behavior to the endpoint
    channelFactory.Endpoint.EndpointBehaviors.Add(endpointClientbehavior);
    
    // done configuring;
    channelFactory.Open();
    var endpoint = new EndpointAddress(
        new Uri(ConfigurationManager.AppSettings["ServiceUrl.Tls12.Info"]));
    // create the clientChannel
    var client = channelFactory.CreateChannel(endpoint);
    client.Open();
    // client implements the operations on InfoWcfWS.IInfo
    
