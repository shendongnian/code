    public ActionResult MyAction()
    {
        userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        // return a list of current user's roleIDs
        var roles = userManager.FindById(User.Identity.GetUserId()).Roles.Select(r => r.RoleId);
    }   
