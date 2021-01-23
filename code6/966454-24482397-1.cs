    [HttpPost]
    public ActionResult SendForm(FormCollection form)
    {
        if (String.IsNullOrEmpty(form["FullName"]))
        {
            ModelState.AddModelError("FullName", "Must enter a name,");
            return View(form);
        }
    //more code…
    }
