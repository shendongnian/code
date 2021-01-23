    public ActionResult AddUserInfo(int id)
    {
    	var model = new ServiceRegistration{ id = id }
    
    	return View(model);
    }
