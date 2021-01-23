    public class IdToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new BitmapImage() { UriSource = new Uri("https://graph.facebook.com/v2.5/" + value.ToString() + "/picture?redirect=true") }
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
                     
