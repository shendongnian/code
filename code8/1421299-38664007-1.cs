    public ActionResult Create()
    {
      var vm = new CreateVm();
      vm.Users= db.Users.Select(f=>new SelectListItem { Value=f.Id.ToString(), 
                                                        Text=f.FullName}).ToList();
      vm.SelectedUserId= 1; // Set the value here
      return View(vm);
    }
