    public ActionResult Create(FormCollection collection)
    {
        if (ModelState.IsValid)
        {
            HttpPostedFileBase file = Request.Files["userUploadedFile"];
    
            var userName = User.Identity.Name;
            var selectAlbum = Request.Form["lstAlbums"];
    
            Image img = new Image();
            img.FileName = file.FileName;
            img.FileType = file.ContentType;
            img.Size = file.ContentLength;
            img.Path = "/uploads/"; //  + userName
            string relativePath = img.Path + img.FileName;
            // relativePath.Replace("/", "\\"); 
            string absolutePath = Server.MapPath(relativePath); 
            file.SaveAs(absolutePath);
            img.Path = relativePath;
            img.User = User;
    
            db.Images.Add(img);
            db.SaveChanges();
    
            return RedirectToAction("Index");
        }
    
        return RedirectToAction("Create");
    }
