    public ActionResult Login(LoginModel model)
    {
         var identity = authenticationClient.GetClaimsIdentity(model.UserName, model.Password);
    
         if (identity == null) {
             return new HttpUnauthorizedResult();
         }
         //Sign in the user
         var ctx = Request.GetOwinContext();
         var authenticationManager = ctx.Authentication;
         authenticationManager.SignIn(identity);
    
         return new HttpStatusCodeResult(HttpStatusCode.OK);
    }
