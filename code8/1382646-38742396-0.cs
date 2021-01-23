    public FileResult Download()
            {
                int Id = Convert.ToInt32(TempData["FileID"]);
                
                var files = _urepo.GetprojectName(Id);
                string filename = (from f in files
                                   select f.PRJ_LOCATION).SingleOrDefault();
                string contentType = "application/zip";
               byte[] fileBytes = System.IO.File.ReadAllBytes(filename);
    
                string file=filename.Substring(filename.LastIndexOf("\\")+1);
                 return File(fileBytes, contentType, file);
            }
