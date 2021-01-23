    public ActionResult Index()
    {
      var vm=new TestModel { Number =10 };    
      return View(vm);
    }
