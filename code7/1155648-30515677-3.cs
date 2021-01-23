    public ActionResult Index()
    {
        var test = new Test() {Id = 1, Name = "Test"};
        return View(test);
    }
