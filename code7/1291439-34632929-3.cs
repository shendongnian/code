    public ActionResult Index(UserViewModel requestResponseModel)
    {
        // Perform validation
        for (var i = 0; i < requestResponseModel.DesiredUnits.Count(); i++)
        {
            var validationErrorKey = string.Format("DesiredUnits[{0}]", i);
            // Is the Name property empty?
            if (string.IsNullOrWhiteSpace(requestResponseModel.DesiredUnits[i].Name))
            {
                
                this.ModelState.AddModelError("Posted Name cannot be empty", validationErrorKey );
            }
        }
        if (this.ModelState.IsValid)
        {
            // There was a model validation error
        }
        //... do something
        // Return the response model
        return View(requestResponseModel);
    }
