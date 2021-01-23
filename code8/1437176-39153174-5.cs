    public class FormsAuthenticationService : IAuthenticationService {
        public void SetAuthCookie(string userName, bool createPersistentCookie) {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
    }
