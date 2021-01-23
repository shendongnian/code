    [Authorize(Roles="Admin")]
    public ActionResult Edit()
    {
        // ...
        return View();
    }
    [Authorize(Roles="Admin")]
    public ActionResult Delete()
    {
        // ...
        return View();
    }
        
