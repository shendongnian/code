    // web service class
    private static Dictionary<Guid, SessionObject> UserSessions = new Dictionary<Guid, SessionObject>();
    private static object SessionLock = new object();
    // session initialize method:
    [WebMethod]
    public Guid CreateNewUserSession()
    {
         SessionObject userobject = new SessionObject();
         Guid SessionGuid = Guid.New();
         lock(SessionLock)
         {
             UserSessions.Add(SessionGuid, userobject);
         }
         return SessionGuid;
    }
    // set the email address    
    [WebMethod]
    public bool SetSessionEmail(Guid SessionGuid, string emailaddress)
    {
         SessionObject temp;
         Lock(SessionLock)
         {
             if(!UserSessions.TryGetValue(SessionGuid, out temp))
             {
                  return false;
             }
         }
         temp.EmailAddress = emailaddress;
         return true;
    }
    
    // sessionobject 
    public class SessionObject
    {
         public string EmailAddress {get; set;}
    }
