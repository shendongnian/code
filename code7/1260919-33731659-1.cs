    public ActionResult Index()
        {
            var model = (from d in db.Users
                         select new UserRoleViewModel()
                         {
                             UserRoleVMId = d.Id,
                             Title = d.Title,
                             FirstName = d.FirstName,
                             Surname = d.Surname,
                             Email = d.Email,
                             AccountEnabled = d.AccountEnabled,
                             Role = string.Join(",", d.Roles.Select                         
                                   (role=>role.Name))}).ToList()
                         }).ToList();
    
            return View(model);
        }
