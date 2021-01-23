    private HttpCookie CreateAuthenticationCookie(int loginId, string username)
    {
        string userData = string.Format("loginId:{0},username:{1}", loginId, username);
        var ticket = new FormsAuthenticationTicket(loginId, username, 
                             DateTime.Now, DateTime.Now.AddYears(1), 
                             false, userData, FormsAuthentication.FormsCookiePath);
        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
        return new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket){{
             Expires = DateTime.Now.AddYears(1);
        }};
    }
