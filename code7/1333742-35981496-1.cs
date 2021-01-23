    public class MyWorkerClass
    {
      private readonly ILoginManager _loginManager;
      public MyWorkerClass(ILoginManager loginManager){
        _loginManager = loginManager;
      }
    
    
      public bool LogOnUser(string userName, string password){
        _loginManager.Authenticate(userName, password);
    
        return _loginManager.IsAuthenticated;
      }
    }
