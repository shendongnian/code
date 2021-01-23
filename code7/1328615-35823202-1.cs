    public ActionResult Index()
    {
      var vm = new YourPageVm();
      //Hard coded for demo. Replace with data from your db
      vm.Categories.Add(new ItemVm { Id=1, Name="Phones" });
      vm.Categories.Add(new ItemVm { Id=2, Name="Books" });
      return View(vm);
    }
