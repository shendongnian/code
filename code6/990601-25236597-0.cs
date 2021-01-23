    public ActionResult Login()
    {
       bool IsValidUser = // Check User Credential
       if(IsValidUser) // If it is valid
       {
          FormsAuthentication.SetAuthCookie("username", false);
          return RedirectToAction("Index");
       }
       else
       {
          //Show the message "Invalid username or password"
       }
