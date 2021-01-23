        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                // model is valid, proceed.
                return RedirectToAction("Success");
            }
            // This returns to the view with the errors
            return View(model);
        }
