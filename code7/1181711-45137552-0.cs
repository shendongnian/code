      public ActionResult ParseCv(HttpPostedFileBase cvFile)
        {            
            byte[] fileInBytes = new byte[cvFile.ContentLength];
            using (BinaryReader theReader = new BinaryReader(cvFile.InputStream))
            {
                fileInBytes = theReader.ReadBytes(cvFile.ContentLength);
            }
            string fileAsString= Convert.ToBase64String(fileInBytes);
            return Content(fileAsString);
        }
