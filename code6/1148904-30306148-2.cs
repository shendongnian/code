    public ActionResult Foo(int id)
    {
        var foo = db.Foos.Find(id);
        if (foo == null)
        {
            return new HttpNotFoundResult();
        }
        return View(foo);
    }
