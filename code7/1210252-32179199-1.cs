    [HttpPost]
    public ActionResult Create(EmployeeModel model)
    {
        if (ModelState.IsValid)
        {
        	// Create avatar on server
            var filename = Path.GetFileName(model.AvatarUrl.FileName);
            var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), filename);
            file.SaveAs(path);
            // Add avatar reference to model and save
            model.AvatarUrl = string.Concat("Uploads/Photo/", filename);
            _db.EventModels.AddObject(model);
            _db.SaveChanges();
    
            return RedirectToAction("Index");
        }
        return View(model);
    }
