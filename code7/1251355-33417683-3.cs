    public ActionResult Register()
    {
      var vm=new CreateUser();
      var allRoles= RoleManager.Roles.ToList();
      vm.RolesList =GetRoles();
    
      return View(vm);     
    }
    private List<SelectListItem> GetRoles()
    {
       var allRoles = System.Web.Security.Roles.GetAllRoles();        
       return allRoles.Select(s => new SelectListItem
            {
                Value = s.roleId.ToString(),
                Text = s.roleName
            });
    }
