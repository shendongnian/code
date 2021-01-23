    public ActionResult ReportView()
    {
        var model = new ReportViewModel();
        //model.EventCategories = ...
        // however you load from your db, eg: db.EventCategories.LoadAll();
        // This assumes you have your EF relationships and/or DB tier 
        // setup correctly so that load eventcategories 
        // also loads each eventcategory.eventCodes
        // possibly:
        model.EventCategories = db.EventCategories.Include("eventCodes").ToList();
        
        return View(model);
    }
