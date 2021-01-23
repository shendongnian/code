      private BitmapImage loadImage(string imgPath)
        {
            BitmapImage myRetVal = null;
            if (imgPath != null)
            {
                BitmapImage img = new BitmapImage();
                using (FileStream stream = File.OpenRead(imgPath))
                {
                    img.BeginInit();
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.StreamSource = stream;
                    img.EndInit();
                }
                myRetVal = image;
            }
            return myRetVal;
        }
