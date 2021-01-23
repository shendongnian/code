    Request.GetOwinContext()
           .Authentication
           .SignOut(HttpContext.GetOwinContext()
                               .Authentication.GetAuthenticationTypes()
                               .Select(o => o.AuthenticationType).ToArray());
