    class Publishing
    {
    public static ServerContract PublishService { get; set; }
    
    public static iSortClientContracts.WCF.ServerProxy WCF_Server { get; set; }
    
    void Publish()
    {
    // Create the Instance of the Service Class.
    serverContract = new ServerContract(); 
    // Create the Service Host using the INSTANCE I just created.
    WCF.Server.ServerHost<WCF.Contracts.ServerContract> WCFServerHost = new WCF.Server.ServerHost<WCF.Contracts.ServerContract>(serverContract, baseAddress); // I am using NetTcpBinding in case someone would like to know.
    
    // Get the Singleton Instance [InstanceMode.Singleton Pattern]
    PublishService = (ServerContract)WCF_Server.SingletonInstance;
    
    List<products> productList = new List<products>(new Product(), new Product());
    
    System.ServiceModel.Channels.CommunicationObject comm = WCF_Server;
    if (comm.State == CommunicationState.Opened)
    {                    
          PublishService.PushProductsToClients(productList);                     
    }
    
    }
    }
