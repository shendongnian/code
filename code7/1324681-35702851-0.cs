        public ActionResult Download()
        {
            var cloudStorageAccount = new CloudStorageAccount(new StorageCredentials("account-name", "account-key"), true);
            var container = cloudStorageAccount.CreateCloudBlobClient().GetContainerReference("test");
            var blobFileNames = new string[] { "file1.png", "file2.png", "file3.png", "file4.png" };
            using (var zipOutputStream = new ZipOutputStream(Response.OutputStream))
            {
                foreach (var blobFileName in blobFileNames)
                {
                    zipOutputStream.SetLevel(0);
                    var blob = container.GetBlockBlobReference(blobFileName);
                    var entry = new ZipEntry(blobFileName);
                    zipOutputStream.PutNextEntry(entry);
                    blob.DownloadToStream(zipOutputStream);
                }
                zipOutputStream.Finish();
                zipOutputStream.Close();
            }
            Response.BufferOutput = false;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "zipFileName.zip");
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.End();
            return null;
        }
