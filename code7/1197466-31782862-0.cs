    public ActionResult GetMyError(int id)
    {
        Error model=_myDb.Get(id);
        model.Description=model.Description.Replace(". ","<br />");
        return View(model);
    }
