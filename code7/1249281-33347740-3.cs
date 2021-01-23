    public ActionResult Create()
    {
      var vm=new UserEditVM();
      var allRoles= RoleManager.Roles.ToList();
      vm.RolesList = allRoles.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                });
    
      return View(vm);     
    }
  
