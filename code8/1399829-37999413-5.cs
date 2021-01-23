    [HttpPost]
    public ActionResult Create(Person person)
    {
        if (ModelState.IsValid)
        {
            //foo
            return RedirectToAction("Index");
        }
    
        return View(person);
    }
