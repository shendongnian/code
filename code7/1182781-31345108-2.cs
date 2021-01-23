    [HttpPost]
    public ActionResult CarImageUpload(CarUploadViewModel model)
    {
        ValidateImageFile validity = new ValidateImageFile(model.ImageUpload); // checks that the file is a jpg
        List<String> issues = validity.Issues;
    
        if (issues.Count > 0)
        {
            ModelState.AddModelError("ImageUpload", "This field is required");
        }
    
        if(ModelState.IsValid)
        {
            model.ImageUpload.SaveAs(V.FilePath);
            RedirectToAction("CarAdmin");
        }
     
        return View(model);
    }
