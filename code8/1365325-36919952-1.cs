    public ActionResult Edit(int id)
    {
      var vm = new YourViewModel();
      vm.beneficiaryNames= beneficiaryNames.Select(s=>new SelectListItem {
                                Value=s.Id.ToString(),
                                Text=s.Name }).ToList();
      vm.BeneficiaryId=2; // Will select the option with value 2, (Record with Id 2)
      return View(vm);
    }
    
