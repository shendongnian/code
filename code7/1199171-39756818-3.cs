        // POST: api/FileUploads
        [ResponseType(typeof(FileUpload))]
        public IHttpActionResult PostFileUpload()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection  
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                if (httpPostedFile != null)
                {
                    FileUpload imgupload = new FileUpload();
                    int length = httpPostedFile.ContentLength;
                    imgupload.imagedata = new byte[length]; //get imagedata  
                    httpPostedFile.InputStream.Read(imgupload.imagedata, 0, length);
                    imgupload.imagename = Path.GetFileName(httpPostedFile.FileName);
                    db.FileUploads.Add(imgupload);
                    db.SaveChanges();
                    // Make sure you provide Write permissions to destination folder
                    string sPath = @"C:\Users\xxxx\Documents\UploadedFiles";
                    var fileSavePath = Path.Combine(sPath, httpPostedFile.FileName);
                    // Save the uploaded file to "UploadedFiles" folder  
                    httpPostedFile.SaveAs(fileSavePath);
                    return Ok("Image Uploaded");
                }
            }
            return Ok("Image is not Uploaded"); 
        }
