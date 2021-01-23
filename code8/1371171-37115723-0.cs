    public ActionResult ProjectDocuments()
    { 
       HttpPostedFileBase upPic = Request.Files["File1"];
       if (upPic != null && upPic.ContentLength != 0 && upPic.InputStream != null)
       {
          //Handle the first file list
       }
       upPic = Request.Files["File2"];
       if (upPic != null && upPic.ContentLength != 0 && upPic.InputStream != null)
       {
         //Handle the first file list
       }
       return View();
    }
