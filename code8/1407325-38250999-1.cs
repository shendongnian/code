    using System;
    using Newtonsoft.Json;
    
    namespace GetHubNetworkStorage
    {
      class Program
      {
        static void Main(string[] args)
        {
          string username = "set me";         
          string apiKey = "set me";
    
          authenticate authenticate = new authenticate();
          authenticate.username = username;
          authenticate.apiKey = apiKey;
    
          SoftLayer_AccountService accountService = new SoftLayer_AccountService();
          accountService.authenticateValue = authenticate;
    
          try
          {
            // The result is an array of SoftLayer_Network_Storage objects and can be either iterated
            // one by one to use the data or being displayed as a JSON value such in this example.
            var hubNetworkStorages = accountService.getHubNetworkStorage();
            string json = JsonConvert.SerializeObject(hubNetworkStorages, Formatting.Indented);
            Console.WriteLine(json);
          }
          catch (Exception e)
          {
            Console.WriteLine("Can't retrieve SoftLayer_Network_Storage information: " + e.Message);
          }
          Console.ReadKey();
        }
      }
    }
