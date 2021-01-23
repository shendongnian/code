        private static void DownloadAFile(Microsoft.SharePoint.Client.ListItem item,string targetPath)
        {
            var ctx = (ClientContext)item.Context;
            var fileRef = (string)item["FileRef"];
            var fileName = System.IO.Path.GetFileName(fileRef);
            var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, fileRef);
            var filePath = Path.Combine(targetPath, fileName);
            using (var fileStream = System.IO.File.Create(filePath))
            {
                fileInfo.Stream.CopyTo(fileStream);
            }
        }
