    [HttpPost]
    public ActionResult Edit(Person p)
    {
        if (ModelState.IsValid)
        {
            var peopleToEdit = new Person
            {
                Name1 = p.Name1,
                Name2 = p.Name2
            };
            //Commit your change
            return RedirectToAction("Index");
        }
        return View("Edit", p);
    }
