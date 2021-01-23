    private string cacheLocalFile(string fileName)
        {
            try
            {
                using (var shell = ShellFile.FromParsingName(fileName))
                {
                    Bitmap bmp = shell.Thumbnail.Bitmap;
                    var cachedFileName = shell.Properties.System.FileName.Value;
                    bmp.Save(Path.Combine(AppCacheDirectory, cachedFileName), ImageFormat.Jpeg);
                    bmp.Dispose();
                    return Path.Combine(AppCacheDirectory, cachedFileName);
                }
            }
            catch
            {
                return String.Empty;
            }
            
        }
