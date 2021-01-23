	public class ImageLoader
    {
        public List<BitmapImage> LoadImages()
        {
            List<BitmapImage> robotImages = new List<BitmapImage>();
            DirectoryInfo robotImageDir = new DirectoryInfo(@"C:\Users\Public\Pictures\Sample Pictures");
            foreach (FileInfo robotImageFile in robotImageDir.GetFiles("*.jpg"))
            {
                Uri uri = new Uri(robotImageFile.FullName);
                robotImages.Add(new BitmapImage(uri));
            }
            return robotImages;
        }
    }
