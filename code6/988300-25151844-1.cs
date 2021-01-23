    public ActionResult Index()
    {
        var DropDownListModel = 
            (from mm in db.roles 
             orderby mm.RoleName
             select new SelectListItem { Text = mn.RoleName, Value = mn.RoleId })
             .ToList();
        return View(new RegisterModel { UserRoles = DropDownListModel });
    }
