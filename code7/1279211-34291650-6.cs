    public IActionResult Index()
    {
        var propertyNames = new List<string>()
        {
            "Name",
            "Email"
        };
        ViewData["PropertyList"] = propertyNames;
        var m = new TestModel()
        {
            Name = "huoshan12345",
            Email = "test@test.net"
        };
        return View(m);
    }
