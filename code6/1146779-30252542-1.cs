        [HttpPost]
        public ActionResult MultipleValidation(List<MyList> model)
        {
            bool isOkay = true;
            string reasonItsInvalid = string.Empty;
            // TODO: Add code to evaluate business rules, and change
            // isOkay and reasonItsInvalid accordingly.
            if (!isOkay)
            {
              // Message to display in validation summary
              ModelState.AddModelError("", "Duplicate Record");
            }
            return View("View", model);
        }
