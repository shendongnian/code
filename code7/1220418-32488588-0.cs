    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        
        HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null && HttpContext.Current.User.Identity.IsAuthenticated)
        {
            if (authCookie != null)
            {
                // get the current cookie
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var fromsIdentity = new FormsIdentity(authTicket);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                CustomPrincipal customPrincipal = new CustomPrincipal(HttpContext.Current.User.Identity.Name);
                CustomIdentitySerializer userData = serializer.Deserialize<CustomIdentitySerializer>(authTicket.UserData);
                if (userData != null)
                {
                    customPrincipal.CustomIdentity.FirstName = userData.FirstName;
                    customPrincipal.CustomIdentity.LastName = userData.LastName;
                    customPrincipal.CustomIdentity.CurrentProject = userData.CurrentProject;
                }
                HttpContext.Current.User = customPrincipal;
            }
        }
    }
