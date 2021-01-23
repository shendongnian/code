    public ActionResult Index(){
        var models = from a in blabla //query what you want here, generate IEnumerable<MyModel>
                     join b in blabla2 on a.class1id equals b.class1id
                     select new MyModel{ name = a.name, from = b.from, to = c.to}
        return View(models);
    }
