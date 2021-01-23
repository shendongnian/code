    public class FormsAuthCookieTicketFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private LegacyFormsAuthenticationTicketEncryptor _Encryptor;
        private Sha1HashProvider _HashProvider;
        public FormsAuthCookieTicketFormat(string decryptionKey, string validationKey)
        {
            _Encryptor = new LegacyFormsAuthenticationTicketEncryptor(decryptionKey);
            _HashProvider = new Sha1HashProvider(validationKey);
        }
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();            
        }
        public string Protect(AuthenticationTicket data, string purpose)
        {
            throw new NotImplementedException();
        }
        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            var ticket = _Encryptor.DecryptCookie(protectedText, _HashProvider);
            
            var identity = new ClaimsIdentity("MyCookie");
            identity.AddClaim(new Claim(ClaimTypes.Name, ticket.Name));
            identity.AddClaim(new Claim(ClaimTypes.IsPersistent, ticket.IsPersistent.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Expired, ticket.Expired.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Expiration, ticket.Expiration.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.CookiePath, ticket.CookiePath));
            identity.AddClaim(new Claim(ClaimTypes.Version, ticket.Version.ToString()));           
            // Add some additional properties to the authentication ticket.
            var props = new AuthenticationProperties();
            props.ExpiresUtc = ticket.Expiration.ToUniversalTime();
            props.IsPersistent = ticket.IsPersistent;
            var principal = new ClaimsPrincipal(identity);
          
            var authTicket = new AuthenticationTicket(principal, props, CookieDetails.AuthenticationScheme);
            return authTicket;
        }
