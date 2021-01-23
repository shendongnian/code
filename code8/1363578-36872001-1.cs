     public ActionResult Foo()
      {
         return View(new MyModel() { Object = new MyObject() });
      }
      [HttpPost]
      public ActionResult Foo(MyModel model)
      {
         return View();
      }
