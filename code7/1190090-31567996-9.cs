        namespace converters
    {
        public class BoolToImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                bool val = (bool)value;
                if (val)
                {
                    return new BitmapImage(new Uri("/images/like.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    return new BitmapImage(new Uri("/images/favs.png", UriKind.RelativeOrAbsolute));
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
