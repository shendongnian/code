    [HttpPost]
    public ActionResult Teste(TesteViewModel model)
    {
        try
        {
    		if(ModelState.IsValid)
    		{
    			// your model is valid!
    		}
    	
            return RedirectToAction("Teste");
        }
        catch
        {
            return View();
        }
    }
