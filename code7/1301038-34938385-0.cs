    [GridAction]
    public ActionResult _GetUsers()
    {
        var users = from user in xcsnEntities.Users
                    select new
                    {
                        Role = user.Roles.FirstOrDefault().RoleName,
                        IsApproved = user.Membership.IsApproved,
                        Email = user.Membership.Email,
                        UserName = user.UserName
                    };
        return View(new GridModel(users));
    }
