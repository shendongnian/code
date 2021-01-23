    public IActionResult Index()
    {
        var currentAccess = this.Context.GetCurrentAccess();
        ...
        return View();
    }
