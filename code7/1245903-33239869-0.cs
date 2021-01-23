    if (ModelState.IsValid)
    { 
        var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        var role = roleMgr.FindById(viewmodel.RoleId);
        if (role != null) userMgr.AddToRole(viewmodel.UserId, role.Name);
    }
