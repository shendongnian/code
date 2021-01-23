    public ActionResult Index()
    {
        var child1 = new Child { Name = "Mikey" };
        var child2 = new Child { Name = "Betsy" };
        var parent = new Parent {
            Name = "John",
            Children = new List<Child>() { child1, child2 }
        };
        return View("Index", parent);
    }
