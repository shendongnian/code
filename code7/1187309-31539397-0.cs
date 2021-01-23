    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Security;
    using System.Web.Security;
    using System.Web.Configuration; 
    namespace AuthAPI
    {
    public class AuthAPI
    {
        public AuthAPI()
        { }
        public void Initialize()
        {
            FormsAuthentication.Initialize();
        }
        public void Initialize1(
             string cookieName,
             string cookieDomain,
             string cookiePath,
             bool slidingExpiration,
             int timeout,
             bool requireSSL
             )
        {
            FormsAuthentication.Initialize(
                  cookieName,
                  cookieDomain,
                  cookiePath,
                  slidingExpiration,
                  timeout,
                  requireSSL
                  );
        }
        public void Initialize2(
              string cookieName,
              string cookieDomain,
              string cookiePath,
              bool slidingExpiration,
              string protection,
              int timeout,
              bool requireSSL,
              string validationKey,
              string decryptionKey,
              string validationMode
              )
        {
            FormsAuthentication.Initialize(
                  cookieName,
                  cookieDomain,
                  cookiePath,
                  slidingExpiration,
                  (FormsProtectionEnum)Enum.Parse(typeof(FormsProtectionEnum), protection, true),
                  timeout,
                  requireSSL,
                  validationKey,
                  decryptionKey,
                  (FormsCryptoValidationMode)Enum.Parse(typeof(FormsCryptoValidationMode), validationMode, true)
                  );
        }
        public string GetAuthCookieValue(
              string userName,
              bool createPersistentCookie)
        {
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(userName, createPersistentCookie);
            return cookie.Value;
        }
        public bool IsAuthenticated(
             string cookieValue,
             out string newCookieValue,
             out DateTime expiration)
        {
            return FormsAuthentication.IsAuthenticated(cookieValue, out newCookieValue, out expiration);
        }
    }
    }
