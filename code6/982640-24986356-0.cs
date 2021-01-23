     [HttpGet] public ActionResult Register()  {
         if (!WebSecurity.Initialized)
         {
             WebSecurity.InitializeDatabaseConnection("UserDb", "Users", "Id", "UserName", autoCreateTables: true);
         }
        return View(); 
}  
    
     [HttpPost] public ActionResult Register(FormCollection form) {
    >     WebSecurity.CreateUserAndAccount(form["username"], form["password"], new{DisplayName = form["displayname"],
    > Country=form["country"]});
    >     Response.Redirect("~/account/login");
    >     return View(); }
    
    **
