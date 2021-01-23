    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
    {
        if (FormsAuthentication.CookiesSupported == true)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                try
                {           
                    string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                    string roles = string.Empty;
                    using (Entities db = new Entities())
                    {
                        Client client = db.Client.SingleOrDefault(x => x.Username== username);
                        if (client.isAdmin)
                        {
                            roles = "Administrator;User";
                        }
                        else
                        {
                            roles = "User";
                        }
                    }
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                      new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                }
                catch (Exception)
                {
                }
            }
        }
    }
