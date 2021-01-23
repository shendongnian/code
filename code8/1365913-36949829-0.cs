    [HttpPost]
    public ActionResult Create(Vara newItm)
    {
        if (ModelState.IsValid)
        {
            ....
        }
        ViewBag.Id = ... // same code as used in the GET method.
        return View(newItm);
    }
