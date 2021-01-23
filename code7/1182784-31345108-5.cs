    [HttpPost]
    public ActionResult CarImageUpload(CarUploadViewModel model)
    {
        ValidateImageFile validity = new ValidateImageFile(model.ImageUpload); // checks that the file is a jpg
        List<String> issues = validity.Issues;
    
        if (issues.Count > 0)
        {
            // TODO: Add more descriptive issue messages
            ModelState.AddModelError("ImageUpload", "There was an issue.");
        }
    
        if(ModelState.IsValid)
        {
            model.ImageUpload.SaveAs(V.FilePath);
            RedirectToAction("CarAdmin");
        }
     
        return View(model);
    }
