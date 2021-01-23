    [HttpPost]
    public ActionResult ConfirmRegistration(string username, string password)
    {
        try
        {
            DoRegistration(username, password);
            //automatically login user after registration
            FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe); 
            //after successful login, redirect to UserPage and render UserPage page
            return RedirectToAction("UserPage", new{username = username, password = password});
        }
        catch(YourLoginFailedExceptioOrWhatEver)
        {    
            return View(username); //login failed, go back to login page      
        }              
    }
    public ActionResult UserPage(string username, string password)
    {
         .......
         return View(information);
    }
