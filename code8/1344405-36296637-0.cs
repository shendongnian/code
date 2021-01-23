    public class SessionInfo
    { 
       public static SessionInfo instance;
       public static SessionInfo GetInstance();
       {          
           if(instance == null)
              instance = new SessionInfo();
           return instance;           
       }
       public string UserName {get; set;}
       public string[] UserRoles {get; set;}
    }
