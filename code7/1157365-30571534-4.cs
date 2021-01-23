    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        try
        {
            string dirFullPath = HttpContext.Current.Server.MapPath("~/MediaUploader/");
            string[] files;
            int numFiles;
            files = System.IO.Directory.GetFiles(dirFullPath);
            numFiles = files.Length;
            numFiles = numFiles + 1;
    
            string str_image = "";
    
            foreach (string s in context.Request.Files)
            {
                HttpPostedFile file = context.Request.Files[s];
                string fileName = file.FileName;
                string fileExtension = file.ContentType;
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileExtension = Path.GetExtension(fileName);
                    str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                    string pathToSave = HttpContext.Current.Server.MapPath("~/MediaUploader/") + str_image;
                    file.SaveAs(pathToSave);
                }
            }
            // database record update logic here  ()
            context.Response.Write(str_image);
        }
        catch (Exception ac) 
        { 
        
        }
    }
