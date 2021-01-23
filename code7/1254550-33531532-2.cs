    public ActionResult ManageUserRoles(string userList)
    {
    
        List<SelectListItem> lbMemberRoles = new List<SelectListItem>();
        List<SelectListItem> lbNonMemberRoles = new List<SelectListItem>();
        var user = (from u in db.Users
                    where u.UserName == userList
                    select u).SingleOrDefault();
    
        // prepopulate roles for the view dropdown
        var roleList = db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
        new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
        var userRoles = UserManager.GetRoles(user.Id);
        foreach (var role in roleList)
        {
            if (userRoles.Contains(role.Value.ToString()))
            {
                lbMemberRoles.Add(role);
            }
            else
            {
                lbNonMemberRoles.Add(role);
            }
        }
        RoleAddRemoveListBoxViewModel lbvm = new RoleAddRemoveListBoxViewModel
        {
            CurrentRolesList = lbMemberRoles,
            NonMemberRolesList = lbNonMemberRoles
        };
    
        return View(lbvm);
    }
