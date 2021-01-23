    public class StringToImageSource: IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                string resourceName = value.ToString();
    
                var img = new BitmapImage();
                img.UriSource = new Uri("Resources/" + resourceName);
    
                return img;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
    }
