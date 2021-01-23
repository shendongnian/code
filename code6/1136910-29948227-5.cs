    public ActionResult Index()
    {
        var vm = SeedFromDatabase();
        return View(vm);
    }
		
    private MyViewModel SeedFromDatabase()
    {
        var vm = new MyViewModel();
        vm.Sites.Add(new Site(0, "one"));
        vm.Sites.Add(new Site(1, "two"));
        vm.Sites.Add(new Site(2, "three"));
        return vm;
    }
