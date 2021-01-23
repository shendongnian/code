    public ActionResult Edit(int id)
    {
      var vm = new EditProfieVm();
      vm.Genders = new List<SelectListItem> { 
             new SelectListItem { Value="M", Text="Male"},
             new SelectListItem { Value="F", Text="FeMale"}
            };
      vm.SelectedGender="F";  //Set the selected option here
      return View(vm);
    }
