    public ActionResult Index()
    {
        var vm = new MyViewModel();
        vm.IsSuperUser = _config.GetSuperUser();
        return View(vm);
    }
