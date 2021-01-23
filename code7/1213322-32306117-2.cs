<!-- -->
    public class MyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = (User)value;
            var someString = (string)paramenter;
            int userId = user.Id;
            string userName = user.Name;
            return ...
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
