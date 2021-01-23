    public class HTTPVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolVisbility  = (value != null) && value.ToString().StartsWith("http");
    
            boolVisbility = (parameter != null) ? !boolVisbility : boolVisbility;
    
            return boolVisbility ? Visibility.Visible : Visibility.Collapsed;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
