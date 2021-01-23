    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string FileName = value as string;
            var file = Windows.Storage.KnownFolders.PicturesLibrary.GetFileAsync(FileName).AsTask().Result;
            var stream = file.OpenReadAsync().AsTask().Result;
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(stream);
            return bitmapImage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
  
