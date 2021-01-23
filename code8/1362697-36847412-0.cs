        private BitmapImage BytesToBitmapImage(byte[] bitmapBytes)
        {
            using (var ms = new MemoryStream(bitmapBytes))
            {
                var bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = ms;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
