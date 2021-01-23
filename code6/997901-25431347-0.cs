    class CommandEnabledToBackgroundConverter : IValueConverter
    {
        public String Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool) value) //if command.Enabled is true
            {
                return new SolidColorBrush(Colors.Gray);
            }
            else
            {
                return new SolidColorBrush(Colors.LightGray);
            }
        }
    
        public bool ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           throw new NotImplementedException();
        }
