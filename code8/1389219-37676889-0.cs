    public ActionResult test(TestModel model)
    {
        var list = new List<Tuple<string, int>>();
        foreach (var i in model.list)
        {
            list.Add(new Tuple<string, int>(i.SomeString, i.SomeInt));
        }
        TempData["Tuple"] = list;
        return RedirectToAction("MyAction", "MyController");
    }
    public ActionResult MyAction()
    {
        System.Diagnostics.Debugger.Break();
        List<Tuple<string, int>> list = TempData["Tupple"] as List<Tuple<string, int>>;
        if (list != null) { /*Do something*/}
        return View();
    }
