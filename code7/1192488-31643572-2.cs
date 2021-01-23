    [HttpPost]
    public ActionResult MyForm(PersonViewModel model)
    {
        if (ModelState.IsValid)
        {
            // do stuff
        }
        return View(model);
    }
    
