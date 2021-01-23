    [HttpPost]
    public ActionResult Index(SendMail input)
    {
      if(!ModelState.IsValid)
          return View(input);     
       //Your existing code here which sends email 
    
    }
