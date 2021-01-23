         public void AddFolder(string folder)
            {
               StorageClient storageClient = StorageClient.Create();
               if (!FolderName.EndsWith("/"))
                 FolderName += "/";         
              var content = Encoding.UTF8.GetBytes("");
            
               storageClient.UploadObject(bucketName, folder, "application/x-directory", new MemoryStream(content));
                 
            }
