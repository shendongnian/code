    public ActionResult OtherAction(string param1)
    {
        var model = this.GenerateModel(param1);
    
        // Use the index View (assuming the controller is called Calendar
        return View("Calendar/Index", model );
    }
