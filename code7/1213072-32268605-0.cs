    // Sample service
    public class Service : IService
    {
       public void SendMessage(string message)
       {
          // do the processing....
       }
    }
    // Creating client connection using factory
    // I can't remember the used of my asterisk here but this is use to identity the configuration name used for the endpoint.
    var result = new ChannelFactory<IService>("*", new EndpointAddress(serviceAddress));
    IService yourService = result.CreateChannel();
    // This will automatically open a connection for you.
    yourService.SendMessage("It works!");
    // Close connection
    result.Close();
