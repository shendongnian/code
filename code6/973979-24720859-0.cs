    // This goes in MyProject.Web/ViewModels ...
    public abstract class UserSecurityViewModel {
        // stuff that is shared between the other ViewModels
        public string Username { get; set; }
        public string Password { get; set; }
        // you get the idea ...
    }
    
    public class RegistrationViewModel : UserSecurityViewModel {
        // Registration specific properties
        public string Email { get; set; }
    }
    
    public class LoginViewModel : UserSecurityViewModel {
        // you don't need the email here ...
        public bool RememberMe { get; set; }
    }
