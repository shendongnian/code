    public ActionResult Index()
    {
        var list1 = new[] { "1", "2", "3", "4", "5" };
        var list2 = new[] { "10", "20", "30", "40", "50" };
        var model = Tuple.Create<IEnumerable<string>, IEnumerable<string>>(list1, list2);
        return View(model);
    }
