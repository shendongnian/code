    private BitmapImage BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            Image i = new Image();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                i.Source = bitmapimage;
                return bitmapimage;
            }
        }
