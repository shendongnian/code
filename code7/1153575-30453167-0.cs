    var folderName = "/Content/Upload/Images/";
    var fileName = file.FileName;
    public void UploadFile(HttpPostedFileBase file)
    {
            using (var fileStream = File.Create(BasePath + folderName + fileName))
            {
                file.InputStream.CopyTo(fileStream);
            }
    }
