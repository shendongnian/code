       public ActionResult UserVerification()
        {
            DataAccess dac = new DataAccess();
            string UserNameApp = HttpContext.User.Identity.Name;
            string UserName = dac.GetLoggedUser(UserNameApp);
            
