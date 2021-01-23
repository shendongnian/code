    [HttpPost]
    public ActionResult Index(CreateStudentVM model)
    {
        if (model != null)
        {
            // TO DO : Save and Redirect
            // PRG Pattern
        }
        return View(model);
    }
