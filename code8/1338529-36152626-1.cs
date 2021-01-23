            List<UploadedFile> uploadedFiles = new List<UploadedFile>();
            var files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                var file = files.Get(i);
                var constructorInfo = typeof(HttpPostedFile).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
                var obj = (HttpPostedFile)constructorInfo
                          .Invoke(new object[] { file.FileName, file.ContentType, file.InputStream });
                uploadedFiles.Add(new UploadedFile(obj));
            }
