    public interface IUserManager {
        string CheckIfAccountExists(string loginName, string email);
        void AddAccount(UserSignUpView userSignUpView);
    }
    public interface IFormsAuthenticationService {
        void SetAuthCookie(string userName, bool createPersistentCookie);
    }
