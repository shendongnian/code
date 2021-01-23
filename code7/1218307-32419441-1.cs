     class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is bool && (bool)value)
            {
                return Application.Current.FindResource("ActiveBrush");
            }
            return Application.Current.FindResource("DefaultBrush");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
