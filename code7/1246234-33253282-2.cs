    //service call code
    ServiceClientFactory clientFactory = new ServiceClientFactory();
    IServiceInterface clientFactory = clientFactory.GetServiceClient("db1ClientType");
    
    //your service call goes here
    clientFactory.DoOperation();
