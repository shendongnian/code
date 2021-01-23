    public ActionResult Create()
    {
      var vm = new CreateEventVm();
      var db= new UltimateDb();
      vm.Members =db.Members.Select(s=> new SelectListItem 
                       { Value=s.Id.ToString(),
                         Text = s.Name
                       }).ToList();
      return View(vm);
    }
