    public ActionResult MyMethod(TestModel tmodel)
            {
                if (string.IsNullOrEmpty(tmodel.property1) && string.IsNullOrEmpty(tmodel.property2))
                {
                    ModelState.AddModelError("property1", "The field property1 can only be empty if property2 is not");
                    ModelState.AddModelError("property2", "The field property2 can only be empty if property1 is not");
                }
    
                if (ModelState.IsValid)
                {
                    return RedirectToAction("otherAction");   //or do whatever you want            
                }
                else
                {
                    //back to form with the errors highlighted
                    return View(tmodel);
                }
            }
