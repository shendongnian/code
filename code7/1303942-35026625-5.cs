    public ActionResult UserList() {
        var userRoles = new List<RolesViewModel>();
        var context = new ApplicationDbContext();
        var userStore = new UserStore<ApplicationUser>(context);
        var userManager = new UserManager<ApplicationUser>(userStore);
    
    
        foreach (var user in userStore.Users)
        {
            var r = new RolesViewModel()
            {
                UserName = user.UserName,
                RoleNames = string.Join(",", userManager.GetRoles(user.Id))
            };
            userRoles.Add(r);
        }
    
        return View(userRoles); 
    }
