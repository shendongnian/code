    public override bool Exists(string filePath)
        {
            try
            {
                string path = Path.GetDirectoryName(filePath);
                var fileName = Path.GetFileName(filePath);
                StorageFolder accessFolder = StorageFolder.GetFolderFromPathAsync(path).AsTask().GetAwaiter().GetResult();
                StorageFile file = accessFolder.GetFileAsync(fileName).AsTask().GetAwaiter().GetResult();
                return file != null;
            }
            catch
            {
                return false;
            }
        }
