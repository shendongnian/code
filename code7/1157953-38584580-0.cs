    public class MyFormsAuthentication : IFormsAuthentication
    {
        public FormsAuthenticationTicket Decrypt(string cookieValue)
        {
            return FormsAuthentication.Decrypt(cookieValue);
        }
    }
