    #region Download File ==>
            public ActionResult downloadfile(string Filename, string MIMEType)
            {
                try
                {
                    string file_name = "/Files/EvidenceUploads/" + Filename;
                    string contentType = "";
                    //Get the physical path to the file.
                    string FilePath = Server.MapPath(file_name);
    
                    string fileExt = Path.GetExtension(file_name);
    
                    contentType = MIMEType;
    
                    //Set the appropriate ContentType.
                    Response.ContentType = contentType;
                    Response.AppendHeader("content-disposition", "attachment; filename=" + (new FileInfo(file_name)).Name);
    
                    //Write the file directly to the HTTP content output stream.
                    Response.WriteFile(FilePath);
                    Response.End();
                    return View(FilePath);
                }
                catch
                {
                    Response.End();
                    return View();
                    //To Do
                }
    
            }
            #endregion
