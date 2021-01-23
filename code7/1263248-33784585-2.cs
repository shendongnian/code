    public ActionResult Create()
    {
      var vm = new EditWeightsViewModel();
      vm.WeeksOfEntryList = weeks.Select(s=> new SelectListItem
                           { Value=s.ToShortDateString(),
                             Text=s.ToShortDateString()}).ToList();
      //If you want to keep one option selected, Set the vm.SelectedWeek property value.
      
      return View(vm);
    }
  
