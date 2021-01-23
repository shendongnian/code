    public ActionResult Edit(int id)
    {
      var vm = new CreateCodeVm();
      var guidVariable = GetGuidFromYourDataBaseSomeHave();
      var parts = guidVariable.ToString().Split('-');
      vm.CodePart1 = parts[0];
      vm.CodePart2 = parts[1];
      vm.CodePart3 = parts[2];
      vm.CodePart4 = parts[3];
    
      return View(vm);
    }
