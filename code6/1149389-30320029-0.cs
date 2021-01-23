    foreach (string one in Request.Files)
    {
         HttpPostedFileBase file = Request.Files[one];
         if ((file != null) && (file.ContentLength > 0) &&    !string.IsNullOrEmpty(file.FileName))
         {
             string fileName = file.FileName;
             string fileContentType = file.ContentType;
             byte[] fileBytes = new byte[file.ContentLength];
             BinaryReader b = new BinaryReader(file.InputStream);
             byte[] binData = b.ReadBytes(file.ContentLength);
         }
    }
