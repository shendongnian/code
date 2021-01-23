    [HttpPost]
    public ActionResult UploadFile(FileUpload obj) 
    {
        using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
        {
           obj.Photo = binaryReader.ReadBytes(Request.Files[0].ContentLength);
        }  
    
        //return some action result e.g. return new HttpStatusCodeResult(HttpStatusCode.OK);
    }
