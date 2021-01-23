     protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            HttpCookie existingCookie = Request.Cookies["UserName"];            
            if (existingCookie != null) {
                 context = new  new GenericPrincipal(new GenericIdentity(existingCookie.Value), new string[]{"Admin", "Manager"});
            } 
        }
