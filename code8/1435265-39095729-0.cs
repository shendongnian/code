    public ActionResult Index()
    {
        modelType model = new modelType()
        //GetModel here
        If(model == null)
        {
            ViewBag.ErrorMsg = "Emtpy Model";
        }
        return View();
    }
