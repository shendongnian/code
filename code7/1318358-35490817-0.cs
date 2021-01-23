    public ActionResult GetFile(int id)
    {
       var f= obj.GetFiles.FirstOrDefault(s=>s.FileId ==id);
       if(f!=null)
       {
          // return the file stream
       }
       // return something else
    }
