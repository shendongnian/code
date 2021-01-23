    public ActionResult Edit(int id)
    {
      var vm = new EditUserVM();
      var user = GetUserFromYourDb(id);
      vm.Name = user.Name
      vm.Email= user.Email
     
      //The below property you don't want user to edit in form. But still sending.
      vm.Token= user.Token
      return View(vm);
    }
