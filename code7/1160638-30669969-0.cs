    public ActionResult Index()
    {
        //do index action related stuff
       BuildDataForDDL();
       return View("index");
    }
    public ActionResult AnotherAction()
    {
        //do another action related stuff
       BuildDataForDDL();
       return View("index");
    }
    private void BuildDataForDDL()
    {
       // build ddl
       //ViewBag.Add(etc,etc);
    }
