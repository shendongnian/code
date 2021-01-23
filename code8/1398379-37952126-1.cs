    [HttpPost]
    public ActionResult Create(PostViewModel model)
    {
        if (ModelState.IsValid)
        {
            //Do all your database/table inserts here.
            //OR connect to your Data Access Layer (DAL)
            //and have it do the inserts.
        }
        return View(model);
    }
