    HttpCookie authCookie = Request.Cookies[
                 FormsAuthentication.FormsCookieName];
        if(authCookie != null)
        {
            //Extract the forms authentication cookie
            FormsAuthenticationTicket authTicket = 
                   FormsAuthentication.Decrypt(authCookie.Value);
            // Create an Identity object
            //CustomIdentity implements System.Web.Security.IIdentity
            CustomIdentity id = GetUserIdentity(authTicket.Name);
            //CustomPrincipal implements System.Web.Security.IPrincipal
            CustomPrincipal newUser = new CustomPrincipal();
            Context.User = newUser;
        }
