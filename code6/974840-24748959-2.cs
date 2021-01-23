    //---------------------------------------------------------------------------------------------------
    public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> files)
    {
        try
         {
              // The Name of the Upload component is "files" 
              if (files == null || files.Count() == 0)
                  throw new ArgumentException("No files defined");
              HttpPostedFileBase file = files.ToArray()[0];
              if (file.ContentLength > 10485760)
                  throw new ArgumentException("File cannot exceed 10MB");
              file.InputStream.Position = 0;
              Byte[] destination = new Byte[file.ContentLength];
              file.InputStream.Read(destination, 0, file.ContentLength);
    
             //do something with destination here
    
         }
         catch (Exception e)
         {
             model.UploadError = e.Message;
         }
         return Json(model, JsonRequestBehavior.AllowGet);
     }
