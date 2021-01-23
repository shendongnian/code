     public static BitmapImage BytesToImage(byte[] bytes)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    bitmapImage.SetSource(ms);
                    return bitmapImage;
                }
            }
            finally { bitmapImage = null; }
        }
        public static byte[] ImageToBytes(BitmapImage img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                WriteableBitmap btmMap = new WriteableBitmap(img);
                System.Windows.Media.Imaging.Extensions.SaveJpeg(btmMap, ms, img.PixelWidth, img.PixelHeight, 0, 100);
                img = null;
                return ms.ToArray();
            }
        }
