    public ActionResult Index()
    {
        try 
	    {	        
		    //Do something
	    }
    	catch (Exception e)
    	{
	    	ViewBag.Error = e.Message;
	    }
        return View();
    }
