    public ActionResult Index(int? page, string[] SelectedRoleIds)
    {
        UserViewModel model = new UserViewModel();
        var users = db.Users;
        var pageNumber = page ?? 1;
        var RoleList = db.Roles;
        model.Roles = new MultiSelectList(RoleList, "RoleId", "Name", model.SelectedRoleIds);
        if (SelectedRoleIds != null)
            model.SelectedRoleIds = Array.ConvertAll(SelectedRoleIds, int.Parse);
        // Filter the users by role selection
        if (model.SelectedRoleIds != null)
        {
            users = users.Where(a => model.SelectedRoleIds.All(requiredId => a.Roles.Any(role => role.RoleId == requiredId)));
        }
        ViewBag.OnePageOfUsers = users.ToPagedList(pageNumber, pagesize); 
        return View(model);
    }
