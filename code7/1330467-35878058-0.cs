    class BooleanToBrushConverter : IValueConverter
        {
            public object Convert(object value, Type targetType,  System.Globalization.CultureInfo culture)
            {
                if ((bool)value)
                {
                    return new SolidColorBrush(Colors.Black);
                }
                return new SolidColorBrush(Colors.LightGray);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
