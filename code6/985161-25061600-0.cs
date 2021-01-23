    [HttpPost]
    public ActionResult MyAwesomePostAction(AddressViewModel model)
    {
        if (!ValidationUtil.IsValidZipCode(model.zip, model.countryID))
        {
            ModelState.AddModelError("zip", "Not a valid zip code for your chosen country.");
        }
        if (ModelState.IsValid)
        {
            ...
        }
        return View(model);
    }
