    public string   UploadFile()
    {
       if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
       {
          var path = System.Web.HttpContext.Current.Request["Path"];
          HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
          var SavePath = Server.MapPath("~/Media/images/") + postedFile.FileName;
          postedFile.SaveAs(SavePath);
       }
       // Need help here to catch extra parameter
       return "Upload success";
    }
