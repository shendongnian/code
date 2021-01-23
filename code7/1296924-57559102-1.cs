    public partial class Config 
    {
    
      partial void Init()
      {
    #if DEBUG
    
        this.ApiKey = "DebugAPIKEY";
        
    #else
        
        this.ApiKey = "ReleaseAPIKEY";
    #endif
      }
    }
