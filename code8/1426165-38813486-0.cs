    public ActionResult Register_step6()
    {
        CoreGeneral cg = new CoreGeneral();
        var model = (from p in db.WorkPointRoles
                     select p).AsEnumerable()
                   .Select(r => new RegisterEmployee_Step6Model()
                     {
                         Role = r.Role,
                         Selected = false,
                         RoleDescription = cg.GetRoleDescription(r.Id)
                     });
        return View(model);
    }
