    FormsAuthenticationTicket authCookie;
    public static string tempTicket = "";
    protected void Application_AuthenticateRequest() {
            
            authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket != null)
                {
                    tempTicket = ticket.Name;
                }
                else
                {
                    tempTicket = "";
                } 
            }
           
        }
