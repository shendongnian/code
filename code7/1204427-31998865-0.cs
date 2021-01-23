    public ActionResult Index()
    {
        //DON'T DO THIS
        //HttpSessionState session = new HttpApplication().Session;
        CustomerStatusModel model = new CustomerStatusModel();
        //USE this.Session INSTEAD
        model.CustomerStatusId = Session["CustomerStatusId"]; 
        return View(model);
    }
