    class ConditionToBackgroundConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if(value.ToString() == "Condition over here")
                {
                    return new SolidColorBrush(System.Windows.Media.Colors.Aqua);
                }else
                {
                    return new SolidColorBrush(System.Windows.Media.Colors.Blue);
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
