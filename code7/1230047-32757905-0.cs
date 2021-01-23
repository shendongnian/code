    public ActionResult Register()
    {
       ViewBag.Title = "Portal";
       var users = from u in db.UsersAndRoles
                           select new
                           {
                               u.Id, u.Name
                           };
       var model = new RegisterUserViewModel
       {
            UsersAsSelectList = new SelectList(users, "Id", "Name");
       }
       return View(model);
    }
