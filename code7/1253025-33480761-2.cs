    public ActionResult Edit(int id)
    {
      var vm = new EditUserVM();
      var user = GetUserFromYourDb(id);
      vm.Name = user.Name
      vm.Email= user.Email
     
      return View(vm);
    }
