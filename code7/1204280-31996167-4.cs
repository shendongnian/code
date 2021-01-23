    // imaging this action is called after user authorized by remote server
    public ActionResoult Login()
    {
        // imaging this method gets authorized certificate string 
        // from Request.ClientCertificate or even a remote server
        var userCer=_certificateManager.GetCertificateString();
        
        // you have own user manager witch return user by certificate string
        var user=_myUserManager.GetUserByCertificate(userCer);
        
        if(user!=null)         
        {
            // user is valid, going to authenticate user for my App
            var ident = new ClaimsIdentity(
                new[] 
                {
                    // since userCer is unique for each user we could easily
                    // use it as a claim. If not use user table ID 
                    new Claim("Certificate", userCer),
                    // populate assigned user's role form your DB 
                    // and add each one as a claim  
                    new Claim(ClaimTypes.Role, user.Roles[0].Name),
                    new Claim(ClaimTypes.Role, user.Roles[1].Name),
                    // and so on
                },
                DefaultAuthenticationTypes.ApplicationCookie);
            // Identity is sign in user based on claim don't matter 
            // how you generated it Identity take care of it
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
           
            // auth is succeed, without needing any password just claim based 
            return RedirectToAction("MyAction"); 
        }
        // invalid certificate  
        ModelState.AddModelError("", "We could not authorize you :(");
        return View();
    }
