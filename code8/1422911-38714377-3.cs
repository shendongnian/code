    public ActionResult Index()
    { 
       if (Request.Files.Count > 0)
       {
          var file = Request.Files[0];    
          if (file != null && file.ContentLength > 0)
          {
             var fileName = Path.GetFileName(file.FileName);
             var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
             file.SaveAs(path);
          }
       }
    }
