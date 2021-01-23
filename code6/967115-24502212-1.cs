    public static void UploadFile() {
    
    int ID = Context.Request.Params["ID"];
    string field = Convert.ToInt32(Context.Request.Params["field"]);
    
    //Get your photo here
    byte[] fileData = null;
    HttpPostedFile postedFile = Context.Request.Files["adPhoto"];
    
    using (var binaryReader = new BinaryReader(postedFile.InputStream))
          {
          fileData = binaryReader.ReadBytes(Context.Request.Files[0].ContentLength);
          }
    
    // Do whatever you have to do at this point...
    
    }
