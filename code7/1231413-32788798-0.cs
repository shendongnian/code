    [HttpGet]
    public virtual ActionResult New()
    {
        return View();
    }
    [HttpPost]
    public virtual ActionResult New(Book entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //Save book
                return RedirectToAction("List");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return View(entity);            
    }
