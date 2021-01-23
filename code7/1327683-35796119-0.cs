    if (ModelState.IsValid)
       {
           string userName = "user123";
           FormsAuthentication.SetAuthCookie(userName , True)
           // do OTP validation
           return this.RedirectToAction("MainMenu", "Options");
        }
        else
        ....
