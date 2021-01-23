    public ActionResult Index()
    {
        // On page load display all data without filters.
    	OverviewFilterModel filter;
    	if (Session["filter"] == null) {
    		var filter = new OverviewFilterModel
    		{
    			Type1 = true,
    			Type2 = true,
    			WorkingOrder = ""
    		};
    	}
    	else {
    		filter = (OverviewFilterModel)Session["filter"];
    	}
    	
    	if (Session["results"] == null){
    		ViewBag.Results = GetResults(filter);
    	}
    	else{
    		ViewBag.Results = Session["results"];
    	}
        
        return View(new HomeModel { Filter = filter });
    }
    
    public ActionResult Search(HomeModel model)
    {
    	if (model.Filter == null)
    	{
    		model.Filter = (OverviewFilterModel)Session["filter"];
    	}
    			
        ViewBag.Results = GetResults(model.Filter);
        return View("Index");
    }
    
    private IEnumerable<OverviewResultModel> GetResults(OverviewFilterModel filter){
    	var data = ...
    	
    	Session["results"] = data;
    	Session["filter"] = filter;
    	
    	return data;
    }
