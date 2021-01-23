    private string cacheLocalFile(string mp3fileName)
        {
            try
            {
                using (var shell = ShellFile.FromParsingName(mp3fileName))
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
