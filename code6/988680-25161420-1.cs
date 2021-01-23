    [HttpPost]
    public ActionResult Create(Assignment assignment)
    {
        if(Request.Files != null && Request.Files.Count == 1)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                var content = new byte[file.ContentLength];
                file.InputStream.Read(content, 0, file.ContentLength);
                assignment.FileLocation = content;
                // the rest of your db code here
            }
        }
        return RedirectToAction("Create");    
    }
