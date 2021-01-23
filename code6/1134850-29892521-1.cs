    public async Task<ActionResult> Details(string id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var role = await RoleManager.FindByIdAsync(id);
        var users = new List<ApplicationUser>();
        foreach (var user in UserManager.Users.ToList())
        {
            if (await UserManager.IsInRoleAsync(user.Id, role.Name))
            {
                users.Add(user);
            }
        }
        RoleUserVM vm = new RoleUserVM();
        vm.Users = users;
        vm.Role = role;
        return View(vm);
    }
