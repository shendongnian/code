    if (model != null)
        {
            model.IsUserAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            if (model.IsUserAuthenticated)
            {
                model.UserName = HttpContext.User.Identity.Name;
            }
        }
