        // if not authenticated, check anti forgery token now:
        if (!User.Identity.IsAuthenticated) 
        {
            System.Web.Helpers.AntiForgery.Validate();
        }
        // run rest of login process normally
        
        ...
