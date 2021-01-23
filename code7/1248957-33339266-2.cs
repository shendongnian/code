    public enum LoginResult
    {
      Success,
      InvalidUserNameOrPasword,
    }
    
    public class UserInfo
    {
      public int Id { get; set; }
      publi string Name { get; set; }
    }
    
    public class Authenticator
    {
      public LoginResult Authenticate(string userName, string password, out userInfo)
      {
        // the logic to load the user from DB
      } 
    }
