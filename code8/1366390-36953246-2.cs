    [HttpGet]
    [ActionName("Index")]
    public ActionResult Index()
    {
         var model = new MyModel();
         return View(model);
    }
