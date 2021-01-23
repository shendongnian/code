    [HttpGet]
    public ActionResult MyForm()
    {
       return View(new PersonViewModel());
    }
    
