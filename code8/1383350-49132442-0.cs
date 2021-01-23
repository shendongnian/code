        // Skip the login process if the user is already logged in
        if (User.Identity.IsAuthenticated) 
        {
            return RedirectToAction("Index", "Home");
        }
        // Check the anti forgery token now
        System.Web.Helpers.AntiForgery.Validate();
        ...
