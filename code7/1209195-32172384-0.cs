        public BitmapSource getImage(string fileName, double width, double height)
        {
            using(FileStream s = File.Open(fileName, FileMode.Open))
            using(Image i = Image.FromStream(s, false, false))
            {
                double iWidth = i.Width;
                double iHeight = i.Height;                
            }
            BitmapImage tmpImage = new BitmapImage();
            tmpImage.BeginInit();
            tmpImage.CacheOption = BitmapCacheOption.OnLoad;
            tmpImage.UriSource = new Uri(fileName);
            if (iWidth > iHeight)
            {
                tmpImage.DecodePixelWidth = (int)width;
            }
            else
            {
                tmpImage.DecodePixelHeight = (int)height;
            }
            tmpImage.EndInit();
            return tmpImage;
        }
    private void whenArrowKeyPressed(int index)
    {
       CurrentImage =  fh.getImage(fileList[index], 1920, 1080);
       
       // Remove this once you finish testing.
       GC.Collect();
       GC.WaitForPendingFinalizers();
    }
