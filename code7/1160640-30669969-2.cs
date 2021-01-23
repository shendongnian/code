    public ActionResult Index()
    {
        //do index action related stuff
       BuildDataForDDL();
       return View("index");
    }
    public ActionResult AnotherAction(YourModel yourModel)
    {
        //do another action related stuff
       BuildDataForDDL();
       ViewBag.Add(SelectedValue, yourModel.DropDownSelectedValue);
       return View("index");
    }
    private void BuildDataForDDL()
    {
       // build ddl
       //ViewBag.Add(etc,etc);
    }
