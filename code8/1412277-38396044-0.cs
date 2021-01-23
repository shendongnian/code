    public class AzureData
    {
       private static AzureDatainstance;
    
       private AzureData() {}
    
       public static AzureDataInstance
       {
          get 
          {
             if (instance == null)
             {
                instance = new AzureData();
             }
             return instance;
          }
       }
       public string MobileServiceUser { get; set; }
    }
