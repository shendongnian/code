    pubic class LoginResult()
    {
    public int EntityType {get;set;}
    public int SurrogateKey {get;set;}
    public string LastName{get;set;}
    public string FirstName{get;set;}
    }
    
    
    public interface IAccountManager
    {
    LoginResult AttemptLogin (string userName, string password)
    }
    public class IAccountManager() : IAccountManager
    {
    public LoginResult AttemptLogin (string userName, string password)
    {
    // put your SqlConnection/SqlReader code here
    }
    }
