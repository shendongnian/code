    public class PaxiumPricipalCreator
    {
        IFormsAuthentication _formsAuthentication;
        public PaxiumPricipalCreator(IFormsAuthentication formsAuthentication)
        {
            _formsAuthentication = formsAuthentication;
        }
        public PaxiumPrincipal CreatePrincipalFromCookie(string cookieValue)
        {
            var authTicket = _formsAuthentication.Decrypt(cookieValue);
            if (authTicket == null)
            {
                return null;
            };
            var userPrincipal = new PaxiumPrincipal(new GenericIdentity(authTicket.Name), null);
            return userPrincipal;
        }
    }
