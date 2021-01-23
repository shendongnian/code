    public ActionResult Foo(int id)
    {
        var foo = db.Foos.Find(id);
        if (foo == null)
        {
            return new HttpNotFoundResult();
        }
        var model = new FooViewModel
        {
            Foo = foo,
            Bar = new SomeModelForForm()
        };
        return View(model);
    }
