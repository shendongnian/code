    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value.ToString();
    
            if (status == "a")
            {
                return new SolidColorBrush(Colors.Red);
            }
    
            return new SolidColorBrush(Colors.Blue);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
