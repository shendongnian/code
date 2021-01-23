    public ActionResult Create(HttpPostedFileBase file)
    {
      // Save the file to the server
      if (file.ContentLength > 0)
      {
        string fileName = Path.GetFileName(file.FileName);
        string path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName); // adjust path to suit
        file.SaveAs(path);
        // Save the path to the database
        Files model = new Files(){ scr = path };
        db.Files.Add(model);
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      // No file was selected so return the view with an error message
      ModelState.AddModelError(string.Empty, "Please select a file");
      return View()
    }
