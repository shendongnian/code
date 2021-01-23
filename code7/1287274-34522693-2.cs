    using MyProject.Models;
    public ActionResult FooMeth(MyModel model)
    {
        if (ModelState.IsValid)
        {
            // Code here if successful.
        }
        // If model is not valid return model with error messages. 
        return View(model);
    }
