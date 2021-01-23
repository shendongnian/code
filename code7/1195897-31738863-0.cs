    public class DropzoneController
    {
    
        private static List<FileObject> files = new List<FileObject>();
    
        public ActionResult SaveDropzoneJsUploadedFiles()
        {   
        
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
        
                // custom file object
                var uploadFile = new FileObject();
        
                // files come through, i get the name
                uploadFile.Name = file.FileName;
        
                // add to list (only adds last object?)
                files.Add(uploadFile);
        
                // files save 
                file.SaveAs(uploadFile.Path);
                // db context saves
                db.Files.Add(uploadFile);
                db.SaveChanges();
            }
        }
    }
