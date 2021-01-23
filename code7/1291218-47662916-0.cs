    public IActionResult Create()
    {
    	ViewData["Tags"] = new SelectList(_context.Tags, "Id", "Name");
    	return View();
    }
        
