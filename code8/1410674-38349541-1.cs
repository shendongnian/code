    public string Upload()
        {
            try
            {
                 for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
    
                    string strTargetFolder = Server.MapPath("~/Junk");
                    
                    if (!Directory.Exists(strTargetFolder))
                    {
                        Directory.CreateDirectory(strTargetFolder);
                    }
                    
                    string targetPath = Path.Combine(strTargetFolder, file.FileName);
                    file.SaveAs(targetPath);
    
                }
                return "Uploaded";
            }
            catch (Exception exp)
            {
                return "ERROR";
            }
     
    
    }
