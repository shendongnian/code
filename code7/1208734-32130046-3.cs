    [HttpGet]
    public ActionResult SomeAction()
    {
         var model = new MyModel();
         model.Variabl1 = "hi";
        
         return View(model);
    }
    [HttpPost]
    public ActionResult SomeAction(MyModel model)
    {
        model.Variable1
    }
