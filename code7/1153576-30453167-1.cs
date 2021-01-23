    public void UploadFile(HttpPostedFileBase file)
    {
            var folderName = "/Content/Upload/Images/";
            var fileName = file.FileName;
            using (var fileStream = File.Create(BasePath + folderName + fileName))
            {
                file.InputStream.CopyTo(fileStream);
            }
    }
