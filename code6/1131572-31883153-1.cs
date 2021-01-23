            protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                //Extract the forms authentication cookie
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JwtSecurityToken jwTok = TokenHelper.GetJWTokenFromCookie(authCookie); 
                // Create the IIdentity instance
                IIdentity id = new FormsIdentity(authTicket);
                // Create the IPrinciple instance
                IPrincipal principal = new GenericPrincipal(id, TokenHelper.GetRolesFromToken(jwTok).ToArray());
                // Set the context user
                Context.User = principal;
            }
        }
