    [HttpPost]
    public ActionResult AddUserInfo(ServiceRegistration model)
    {
    
    	var db = new ShareRideDBEntities();
    
    	if(ModelState.IsValid)
    	{
    
    		//Find your user in your db context using model.Id as the reference
    		
    		//Add the User Data from the model
    		
    		db.SaveChanges();
            
            return RedirectToAction("Index", "Controller");
    
    	}	
        
        //Form isn't valid so return form will the validation errors
        return View(model);
    
    }
