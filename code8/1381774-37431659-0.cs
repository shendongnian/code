    [HttpPost]
    public ActionResult Method(FormVM model)
    {
    	if (ModelState.IsValid) 
    	{
    		// ... other processing code and action returns
    	}
    	
    	if (!(model.Property1 || model.Property2 || model.Property3))
    	{
    		ViewData["Error"] = "You must select at least one property." // this can be changed with ViewBag
    
    		// immediately return the same page
    		return View(model);
    	}
    }
