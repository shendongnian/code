    public ActionResult AddUserInfo(Guid id)
    {
    	var model = new ServiceRegistration{ id = id }
    
    	return View(model);
    }
