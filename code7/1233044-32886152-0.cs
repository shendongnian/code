    public class FormsAuthWrapperTest : IAuthenticationProvider
    {
        public void SignOut()
        {
           // MockFormsAuthentication.SignOut();
           // Mock your Authentication here
        }
        public void SetAuthCookie(string username, bool remember)
        {
           //MockFormsAuthentication.SetAuthCookie(username, remember);
           //Mock your Authentication here
        }
        public void RedirectFromLoginPage(string username, bool createPersistentCookie)
        {
            MockFormsAuthentication.RedirectFromLoginPage(username, createPersistentCookie);
           //Mock your Authentication here
        }
    }
