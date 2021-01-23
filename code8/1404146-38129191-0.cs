    HttpPostedFileBase file = Request.Files[inputTagName];
    var uploadedFile = new byte[file.InputStream.Length];
    using (DBEntities ode = new DBEntities())
    {
        (check if file exists...)
        else
        {  
                MyModels.File newfile = new MyModels.File();
                newfile.ID = Guid.NewGuid();
                newfile.Name = fn;
                newfile.VirtualPath = filePath;
                newfile.DateTimeUploaded = DateTime.Now;
                newfile.binFile = uploadedFile;
                ode.AddToFiles(newfile);
        }
        
        ode.SaveChanges();
    }
