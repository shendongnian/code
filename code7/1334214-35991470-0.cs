    public ActionResult Index()
    {
        var myTestId = 0;
        return RedirectToAction("Site", new { testId = myTestId });
    }
    public ActionResult Site(int myId)
    {
        return RedirectToAction("Foo", new { testId = myId });
    }
