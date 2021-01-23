        [HttpPost]
        public ActionResult Create(string submitButton)
        {
            var model = new MyClass();  // go and get the record you want to edit
            if (submitButton == "Save")
            {
                TryUpdateModel(model);
                if (!ModelState.IsValid) // if the modelstate isn't valid, setup the dropdowns for the return trip to the form
                {
                    ViewData["OrganizationId"] = model.OrganizationId;
                    ViewBag.RecordTypes = GetRecordTypes(model.OrganizationId);
                    return View(model);
                }
                context.AddToMyType(model);
                context.SaveChanges(); // save changes if there are no errors
            }
            return RedirectToAction("Index", new { id = model.OrganizationId });
        }
