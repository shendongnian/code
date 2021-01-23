    public ActionResult Show()
    {
      var vm=new CreateOrderVM();
      vm.Modes = GetModes();
    
      //Set one of them as selected
      vm.SelectedMode="B";
    
      return View(vm);
    }
    private List<SelectListItem> GetModes()
    {
      var list=new List<SelectListItem>();
      //hard coded for demo.Replace with actual values
      list.Add(new SelectListItem { Value="A", Text="A"});
      list.Add(new SelectListItem { Value="B", Text="B"});
      list.Add(new SelectListItem { Value="C", Text="C"});
      return list;
    }
