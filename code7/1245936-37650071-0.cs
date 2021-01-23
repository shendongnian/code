    // get the provider name
    var authCtx = HttpContext.GetOwinContext();
    var usrMgr = authCtx.GetUserManager<ApplicationUserManager>();
    var user = usrMgr.FindByName(HttpContext.User.Identity.Name);
    var extLoginInfo = usrMgr.GetLogins(user.Id).FirstOrDefault();
    var loginProvider = extLoginInfo.LoginProvider.ToLower();
