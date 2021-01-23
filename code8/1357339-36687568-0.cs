    // Read this from your config instead...
    string server = ConfigurationManager.AppSettings["Server"]
    string address = $"http://{server}:8003/TestMatchService/TestMatchService";
    var binding = new BasicHttpBinding();
    var endpoint = new EndpointAddress(address);
    var channelFactory = new ChannelFactory<ITestMatchService>(binding, endpoint);
    ITestMatchService client = channelFactory.CreateChannel();
