    var user = UserManager.FindById(id);
    var userRoles = UserManager.GetRoles(user.Id);
    return View(new UserViewModel()
    {
        Id = user.Id,
        RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
        {
            Selected = userRoles.Contains(x.Name),
            Text = x.Name,
            Value = x.Name
        })
    });
