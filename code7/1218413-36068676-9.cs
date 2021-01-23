    public interface IAuthenticationService {
        bool Authenticate(string username, string password);   
    }
    public interface IFormsAuthenticationService {
        void SetAuthCookie(string userName, bool createPersistentCookie);
        void SignOut();
    }
