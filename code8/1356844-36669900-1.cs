    public ActionResult Index()
      {
        var recepy= LoadRecipe();
        return View(recepy); //passing the DataTable to the View
      }
    
