    public BitmapImage LoadBackgroundImage(string fileName)
    {
                var image = new BitmapImage();
                try
                {
                    image.BeginInit();
                    if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                    {
                        var bytes = File.ReadAllBytes(fileName);
                        image.StreamSource = new MemoryStream(bytes);
                    }
                    else
                    {
                        var bytes = File.ReadAllBytes(Path.GetFullPath(Properties.Resources.DefaultBackgroundImage));
                        image.StreamSource = new MemoryStream(bytes);
                    }
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    image.Freeze();
                }
                catch (FileNotFoundException ex)
                {
                      throw ex;
                }
    
                return image;
            }
