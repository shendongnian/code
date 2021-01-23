    public ActionResult Index()
    {
        var vm = new MyViewModel();
        vm.Sites.Add(new Site(0, "one"));
        vm.Sites.Add(new Site(1, "two"));
        vm.Sites.Add(new Site(2, "three"));
        return View(vm);
    }
