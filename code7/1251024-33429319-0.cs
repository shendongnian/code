    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var CapturedImage = new BitmapImage();
                CapturedImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                if (((string)value).StartsWith("ms-appx:"))
                {
                    CapturedImage.UriSource = new Uri((string)value, UriKind.RelativeOrAbsolute);
                    return CapturedImage;
                }
                var file = (StorageFile.GetFileFromPathAsync(new Uri((string)value, UriKind.RelativeOrAbsolute).LocalPath).AsTask().Result);
                using (IRandomAccessStream fileStream = file.OpenAsync(FileAccessMode.Read).AsTask().Result)
                {
                    CapturedImage.SetSource(fileStream);
                    return CapturedImage;
                }
            }
            catch (Exception e)
            {
                Logger.Error("Exception in the image converter!", e);
                return new BitmapImage();
            }
            //BitmapImage img = null;
            //if (value is string)
            //{
            //    img = new BitmapImage();
            //    img.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            //    img.UriSource = new Uri((string)value, UriKind.RelativeOrAbsolute);
            //}
            //if (value is Uri)
            //{
            //    img = new BitmapImage();
            //    img.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            //    img = new BitmapImage((Uri)value);
            //}
            //return img;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
