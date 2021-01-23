    public class LoginResult
    {
        public LoginStatus Status { get; set; }
    
        public int AttemptsRemaining { get; set; }
    }
    
    public enum LoginStatus : int
    {
        Authorized = 0,
        InvalidCredentials = 1,
        Suspended = 2
    }
