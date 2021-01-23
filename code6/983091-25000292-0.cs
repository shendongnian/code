    public ActionResult Test()
    {
    	var dictionary = new Dictionary<int, string>
    	{
    		{ 1, "One" },
    		{ 2, "Two" },
    		{ 3, "Three" }
    	};
    
    	ViewBag.SelectList = new SelectList(dictionary, "Key", "Value");
    
    	return this.View();
    }
