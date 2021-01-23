    [httpPost]
    public ActionResult Index(Contact model)
       {
        if (!ModelState.IsValid)
        {
             //write  the code  that saves to database
        }
      
        return View();
    }
