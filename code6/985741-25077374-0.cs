    private string GetCurrentURL()
    {
      string appPath = Request.ApplicationPath.ToString();
      string[] strPath = Request.RawUrl.ToString().Split('/');
      if (strPath.Count() == 2)
      {
          return Request.RawUrl.ToString().Replace(appPath, "")
      }
      else
      {
         return Request.RawUrl.ToString().Replace(appPath, "").Substring(1));
      }
    }
