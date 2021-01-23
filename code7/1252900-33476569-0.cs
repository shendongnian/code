    [HttpPost]
    public ActionResult Action1(Model user)
    {
        if (ModelState.IsValid)
        {
        // do some stuff here
        }
        else
        {
            return this.RedirectToAction ("Action1", new { value1 = "QueryStringValue" });
        }
    }
