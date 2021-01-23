    class IdToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var idValue = value.ToString();
            var url = string.Format("http://myurl.com/{0}", idValue);
            return new BitmapImage(new Uri(url));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
