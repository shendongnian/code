    public class ImageConverter : IValueConverter
    {
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                string imageUrl = value.ToString();
                if (imageUrl.Contains("NoImageIcon"))
                    return value;
                if (imageUrl.Contains(Constants.IMAGES_FOLDER_PATH))
                {
                    var task = Task.Run(()=>( (GetImage((String)value))));
                    return task;
                   
                }
                if (imageUrl.Contains("mp4"))
                {
                   return Task.Run(() => ((GetImage("ms-appx:///Images/video.png"))));
                    
                    
                }
                if (MCSManager.Instance.isInternetConnectionAvailable)
                {
                    return Task.Run(() => (GetImage(value.ToString(), true)));
                }
                else
                {
                    var task = Task.Run(() => ((GetImage("ms-appx:///Images/defaultImage.png"))));
                    return task;
                }
            }
            return new Uri("ms-appx:///Images/defaultImage.png", UriKind.RelativeOrAbsolute);
        }
        private async Task<BitmapImage> GetImage(string path,bool link=false)
        {
            BitmapImage image = new BitmapImage();
            if (link)
            {
                image.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            }
            else
            {
                image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                StorageFile imagefile = await localFolder.GetFileAsync(path);
                using (IRandomAccessStream fileStream = await imagefile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    image.SetSource(fileStream);
                    return image;
                }
            }
          
           
        }
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return null;
        }
        private async Task<bool> FileExists(string fileName)
        {
            try
            {
                StorageFile file = await localFolder.GetFileAsync(fileName);
                return true;
            }
            catch (FileNotFoundException ex)
            {
                return false;
            }
        }
    }
