    [HttpPost]
    public ActionResult CalendarIndex(CalendarArg model)
    {
         // Check that model is valid
        if(ModelState.IsValid)
        {
            // CODE here to update Database
            return RedirectToAction("Index"); // or where ever you want to go
        }
        else
        {
            return View(model); // Return back to View, model is not valid
        }
    }
