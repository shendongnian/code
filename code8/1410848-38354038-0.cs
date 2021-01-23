    public ActionResult Show()
    {
      var vm = new YourViewModel();
      vm.CountriesDDL = GetCountriesFromSomeWhere();
      vm.Country="United States";
      return View(vm);
    }
