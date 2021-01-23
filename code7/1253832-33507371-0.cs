    public ActionResult Edit()
    {
      var vm = new YourViewModel(int id);
      vm.ProductionEnvironment_Servers = servers.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                });
     
      //Set the value you want to be selected.
     Guid guidWhichShouldBeSelected = GetSelectedGuidHereFromSomeWhere(id);
    
     vm.ProductionEnvironment_ServerId = guidWhichShouldBeSelected;
     return View(vm);
    }
