    public partial class Config
    {
    
      public Config()
      {
          Init();
      }
    
      partial void Init();
    
      public string ApiKey{ get; private set; }= "DefaultValueAPIKEY";
    }
