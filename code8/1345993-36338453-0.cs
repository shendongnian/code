    using System;
    
    struct CustomerIdentifications
    {
        private string _customerID;
        private string _uniqueIdentifier;
        
        public CustomerIdentifications(string customerId, string uniqueId)
        {
          _customerID = customerId;
          _uniqueIdentifier = uniqueId;
        }
    
        public string CustomerID { get { return _customerID ?? "1010"; } }
        public string UniqueIdentifier { get { return _uniqueIdentifier ?? "1234"; } }
    }
    
    class App
    {
      public static void Main()
      {
        var id = GenerateToken<CustomerIdentifications>();
        Console.WriteLine(id.CustomerID);
        Console.WriteLine(id.UniqueIdentifier);
      }
      
      public static T GenerateToken<T>(T userInfo = default(T))
      {
        // stuff
        return userInfo;
      }
    }
