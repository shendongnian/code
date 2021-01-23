    public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
    {
       
        var savedFilePaths = new List<string>();
        var applicationPath = System.Web.HttpContext.Current.Request.Url.Scheme + "://" + System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.ApplicationPath + "/Content/Images/Others/";
        // The Name of the Upload component is "files"
        if (files != null)
        {
            foreach (var file in files)
            {
                // Some browsers send file names with full path.
                // We are only interested in the file name.
                var fileName = Path.GetFileName(file.FileName);
                if (fileName != null)
                {
                     fileName = DateTime.Now.ToString("yyyyMMddmm-") + fileName;
                    var physicalPath = Path.Combine(Server.MapPath("~/Upload/Hotel"), fileName);
                    file.SaveAs(physicalPath);
                    savedFilePaths.Add(applicationPath + fileName);
                }
               
            }
        }
        // Return an empty string to signify success
        return Content("");
    }
