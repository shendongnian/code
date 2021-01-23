        public static void ImageRetrival(PHG.OneDrive.Helpers.OneDriveHelper oneDrive, string user)
        {
            try
            {
                var wb = userContext.Web;
                userContext.Load(wb);
                var files = oneDrive.GetOneDriveFilesByFolderName(user);
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        // has to be inside my foreach loop referencing file in files which represents a sharepoint filecollection 
                        var fileinfo  = Microsoft.SharePoint.Client.File.OpenBinaryDirect(userContext, file.ServerRelativeUrl);
                        var fileName = file.Name.ToString();
                        string path = @"C:\Top-Level\" + fileName;
                        using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            fileinfo.Stream.CopyTo(fs);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
