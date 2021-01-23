    public ActionResult Create()
    {
      var vm = new CreateSiteVm();
      vm.TypeMenus = dbContext.TypeMenus.Select(x=> new SelectListItem { 
                                                               Value=x.Id.ToString(),
                                                               Text=x.Name}).ToList();
      return View(vm);
    }
