    @functions {
    
       string SomeWayToShow(string path)
       {
           var filePath = System.Web.HttpContext.Current.Server.MapPath(path);
    
           if (System.IO.File.Exists(filePath))
              return System.IO.File.ReadlAllText(filePath);
    
           return string.Empty;
       }
    
    }
