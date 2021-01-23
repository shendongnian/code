    public class FormsAuthenticationService : IFormsAuthenticationService {
        public void SetAuthCookie(string userName, bool createPersistentCookie) {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
    }
