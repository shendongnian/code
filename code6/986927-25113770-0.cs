    [HttpPost]
    public ActionResult Upload(UploadViewModel model, HttpPostedFileBase file)
    {
     if (file != null)
     {
        int byteCount = file.ContentLength;   <---Your file Size or Length
        .............
        .............
     }
    }
