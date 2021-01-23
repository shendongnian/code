    public ActionResult CreateUserWithImage()
    {
       if (Request.Files != null && Request.Files.Count>0)
       {
            var f = Request.Files[0];
            UploadFile(f,"Some","Abc");
       }
       return Content("Please return something valid here");
    }      
    private string UploadFile(HttpPostedFileBase file, string SubPath, string folder)
    {
       //do something with the file now and return some string
    }
