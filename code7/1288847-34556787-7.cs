    public class ImageConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var path = string.Format(@"C:\Users\{0}.png", value);
                return new BitmapImage(new Uri(path));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
