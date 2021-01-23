    public ActionResult TestSection(int id)
    {
         List<TestModel> models = new List<TestModel>();
         // Populate your list and send it to the view
    
         return View(models);
    }
    [HttpPost]
    public ActionResult TestSection(int id, List<TestModel> model)
    {
         // Do what ever you need to do
         return View();
    }
